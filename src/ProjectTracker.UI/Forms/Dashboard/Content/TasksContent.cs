using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Tile;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskStatus = ProjectTracker.Core.Enums.TaskStatus;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    public partial class TasksContent : UserControl
    {
        private readonly ITaskService _taskService;
        private List<TaskDto> _allTasks;

        // Repository Items
        private RepositoryItemButtonEdit _actionButtonsRepository;
        private RepositoryItemProgressBar _progressBarRepository;

        // View State
        private bool _isKanbanView = false;

        public TasksContent(ITaskService taskService)
        {
            InitializeComponent();
            _taskService = taskService;

            InitializeGrid();
            InitializeKanban();
            SetupEvents();

            // Ilk y�kleme
            this.Load += async (s, e) => await LoadDataAsync();
        }

        public TasksContent()
        {
            InitializeComponent();
        }

        private void InitializeGrid()
        {
            // --- ProgressBar ---
            _progressBarRepository = new RepositoryItemProgressBar();
            _progressBarRepository.Minimum = 0;
            _progressBarRepository.Maximum = 100;
            _progressBarRepository.ShowTitle = true;
            _progressBarRepository.PercentView = true;
            _progressBarRepository.Appearance.BackColor = Color.FromArgb(42, 42, 42);
            _progressBarRepository.Appearance.ForeColor = Color.ForestGreen;

            if (gridView1.Columns["CompletionPercentage"] != null)
                gridView1.Columns["CompletionPercentage"].ColumnEdit = _progressBarRepository;

            // --- Action Buttons (Edit/Delete) ---
            _actionButtonsRepository = new RepositoryItemButtonEdit();
            _actionButtonsRepository.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            _actionButtonsRepository.Buttons.Clear();

            var editBtn = new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph);
            editBtn.Caption = "?";
            editBtn.ToolTip = "Edit Task";

            var deleteBtn = new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph);
            deleteBtn.Caption = "??";
            deleteBtn.ToolTip = "Delete Task";

            _actionButtonsRepository.Buttons.Add(editBtn);
            _actionButtonsRepository.Buttons.Add(deleteBtn);
            _actionButtonsRepository.ButtonClick += ActionButtonsRepository_ButtonClick;

            if (grdTasks.RepositoryItems.IndexOf(_actionButtonsRepository) < 0)
                grdTasks.RepositoryItems.Add(_actionButtonsRepository);

            if (gridView1.Columns["Actions"] != null)
                gridView1.Columns["Actions"].ColumnEdit = _actionButtonsRepository;
        }

        private void SetupEvents()
        {
            if (_taskService == null) return; // Designer mode check

            btnRefresh.Click += async (s, e) => await LoadDataAsync();
            btnNewTask.Click += BtnNewTask_Click;
            btnClearFilters.Click += BtnClearFilters_Click;
            btnViewSwitcher.Click += BtnViewSwitcher_Click;

            gridView1.CustomDrawCell += GridView1_CustomDrawCell;

            // Search & Filter Events
            txtSearch.EditValueChanged += (s, e) => ApplyFilters();
            cmbStatusFilter.SelectedIndexChanged += (s, e) => ApplyFilters();
            cmbPriorityFilter.SelectedIndexChanged += (s, e) => ApplyFilters();
        }

        // --- Data Loading & Filtering ---
        private async System.Threading.Tasks.Task LoadDataAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var tasks = await _taskService.GetAllTasksAsync();
                _allTasks = tasks.ToList();

                ApplyFilters();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ApplyFilters()
        {
            if (_allTasks == null) return;

            var filtered = _allTasks.AsEnumerable();

            // Search Text
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                string search = txtSearch.Text.ToLower();
                filtered = filtered.Where(t =>
                    t.TaskName.ToLower().Contains(search) ||
                    (t.ProjectName != null && t.ProjectName.ToLower().Contains(search)));
            }

            // Status Filter - Map UI text to actual enum values
            if (cmbStatusFilter.SelectedIndex > 0 && cmbStatusFilter.Text != "All Status")
            {
                // Map UI-friendly names to database enum values
                string statusValue = cmbStatusFilter.Text switch
                {
                    "ToDo" => "Pending",
                    "InProgress" => "InProgress",
                    "Done" => "Completed",
                    "Blocked" => "Blocked",
                    _ => cmbStatusFilter.Text
                };
                
                filtered = filtered.Where(t => t.Status == statusValue);
            }

            // Priority Filter
            if (cmbPriorityFilter.SelectedIndex > 0 && cmbPriorityFilter.Text != "All Priority")
            {
                string priorityValue = cmbPriorityFilter.Text;
                filtered = filtered.Where(t => t.Priority == priorityValue);
            }

            var resultList = filtered.ToList();

            // Update Grid
            grdTasks.DataSource = resultList;
            lblRecordCount.Text = $"Showing {resultList.Count} of {_allTasks.Count} tasks";

            // Update Kanban if visible
            if (_isKanbanView)
            {
                BindKanbanData(resultList);
            }
        }

        // --- Event Handlers ---
        private void BtnClearFilters_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbStatusFilter.SelectedIndex = 0;
            cmbPriorityFilter.SelectedIndex = 0;
        }

        private void BtnViewSwitcher_Click(object sender, EventArgs e)
        {
            _isKanbanView = !_isKanbanView;

            if (_isKanbanView)
            {
                btnViewSwitcher.Text = "📄 List View";
                grdKanban.Visible = true;
                grdTasks.Visible = false;
                
                // Bind data to Kanban
                if (_allTasks != null)
                {
                    ApplyFilters();
                }
            }
            else
            {
                btnViewSwitcher.Text = "📊 Kanban View";
                grdKanban.Visible = false;
                grdTasks.Visible = true;
            }
        }

        private void BtnNewTask_Click(object sender, EventArgs e)
        {
            // Open TaskDetailControl
            var detailControl = Program.ServiceProvider.GetRequiredService<TaskDetailControl>();
            ((FrmDashboard)this.ParentForm).LoadContent(detailControl);
        }

        private async void ActionButtonsRepository_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = gridView1;
            var rowHandle = view.FocusedRowHandle;
            if (rowHandle < 0) return;

            var task = view.GetRow(rowHandle) as TaskDto;
            if (task == null) return;

            if (e.Button.Caption == "?")
            {
                // Edit Task
                var detailControl = Program.ServiceProvider.GetRequiredService<TaskDetailControl>();
                detailControl.LoadTaskForEdit(task.TaskId);
                ((FrmDashboard)this.ParentForm).LoadContent(detailControl);
            }
            else if (e.Button.Caption == "??")
            {
                if (XtraMessageBox.Show($"Are you sure you want to delete '{task.TaskName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    await _taskService.DeleteTaskAsync(task.TaskId);
                    await LoadDataAsync();
                }
            }
        }

        // --- Custom Drawing (Badges) ---
        private void GridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Status")
            {
                e.Appearance.DrawBackground(e.Cache, e.Bounds);
                string status = e.CellValue?.ToString() ?? "";
                Color color = status == "Done" ? Color.ForestGreen :
                              status == "InProgress" ? Color.Orange :
                              status == "ToDo" ? Color.Gray : Color.Red;

                // Draw badge (Circle)
                e.Cache.FillEllipse(color, new Rectangle(e.Bounds.X + 5, e.Bounds.Y + 8, 10, 10));

                // Draw text
                e.Appearance.DrawString(e.Cache, status, new Rectangle(e.Bounds.X + 20, e.Bounds.Y, e.Bounds.Width - 20, e.Bounds.Height));

                e.Handled = true;
            }
            else if (e.Column.FieldName == "Priority")
            {
                string priority = e.CellValue?.ToString() ?? "";
                Color color = priority switch
                {
                    "Critical" => Color.FromArgb(239, 68, 68),    // Red-500
                    "High" => Color.FromArgb(251, 146, 60),        // Orange-400
                    "Medium" => Color.FromArgb(14, 165, 233),      // Sky-500
                    "Low" => Color.FromArgb(16, 185, 129),         // Emerald-500
                    _ => Color.FromArgb(161, 161, 161)
                };

                e.Appearance.DrawBackground(e.Cache, e.Bounds);
                e.Cache.DrawString(priority, e.Appearance.Font, new SolidBrush(color), e.Bounds, e.Appearance.GetStringFormat());
                e.Handled = true;
            }
        }

        #region Kanban View Methods (TileView)

        /// <summary>
        /// Initializes DevExpress TileView Kanban
        /// </summary>
        private void InitializeKanban()
        {
            // ===== CREATE TILE COLUMNS =====
            tileViewKanban.Columns.Clear();
            
            // First add Status column (needed for grouping)
            var colStatus = tileViewKanban.Columns.AddField("Status");
            colStatus.Caption = "Status";
            colStatus.Visible = false; // Hidden, used only for grouping
            
            // Set as group column
            tileViewKanban.ColumnSet.GroupColumn = colStatus;
            
            // Add other tile columns
            var colTaskName = tileViewKanban.Columns.AddField("TaskName");
            colTaskName.Caption = "Task";
            colTaskName.Visible = true;
            
            var colProject = tileViewKanban.Columns.AddField("ProjectName");
            colProject.Caption = "Project";
            colProject.Visible = true;
            
            var colPriority = tileViewKanban.Columns.AddField("Priority");
            colPriority.Caption = "Priority";
            colPriority.Visible = true;
            
            var colDueDate = tileViewKanban.Columns.AddField("DueDate");
            colDueDate.Caption = "Due Date";
            colDueDate.DisplayFormat.FormatString = "dd MMM yyyy";
            colDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colDueDate.Visible = true;
            
            // ===== CREATE MANUAL KANBAN GROUPS =====
            tileViewKanban.OptionsKanban.Groups.Clear();
            
            tileViewKanban.OptionsKanban.Groups.Add(new KanbanGroup 
            { 
                Caption = "TO DO",
                GroupValue = "Pending",
                AllowItemDrag = true
            });
            tileViewKanban.OptionsKanban.Groups.Add(new KanbanGroup 
            { 
                Caption = "IN PROGRESS",
                GroupValue = "InProgress",
                AllowItemDrag = true
            });
            tileViewKanban.OptionsKanban.Groups.Add(new KanbanGroup 
            { 
                Caption = "COMPLETED",
                GroupValue = "Completed",
                AllowItemDrag = true
            });
            tileViewKanban.OptionsKanban.Groups.Add(new KanbanGroup 
            { 
                Caption = "BLOCKED",
                GroupValue = "Blocked",
                AllowItemDrag = true
            });
            
            // Note: Appearance settings and tile size are configured in Designer
            
            // ===== EVENTS =====
            tileViewKanban.BeforeItemDrop += TileViewKanban_BeforeItemDrop;
            tileViewKanban.ItemDoubleClick += TileViewKanban_ItemDoubleClick;
            tileViewKanban.ItemCustomize += TileViewKanban_ItemCustomize;
        }
        


        /// <summary>
        /// Binds tasks to TileView Kanban
        /// </summary>
        private void BindKanbanData(List<TaskDto> tasks)
        {
            grdKanban.DataSource = tasks;
            tileViewKanban.RefreshData();
        }

        /// <summary>
        /// Handles tile drop event before drop completes (drag & drop)
        /// </summary>
        private async void TileViewKanban_BeforeItemDrop(object sender, EventArgs e)
        {
            try
            {
                // Use reflection to access event args properties
                var eventType = e.GetType();
                var rowHandleProperty = eventType.GetProperty("RowHandle");
                var newGroupColumnValueProperty = eventType.GetProperty("NewGroupColumnValue");
                var cancelProperty = eventType.GetProperty("Cancel");
                
                if (rowHandleProperty == null || newGroupColumnValueProperty == null)
                    return;
                
                int rowHandle = (int)rowHandleProperty.GetValue(e);
                var task = tileViewKanban.GetRow(rowHandle) as TaskDto;
                
                if (task == null)
                {
                    if (cancelProperty != null)
                        cancelProperty.SetValue(e, true);
                    return;
                }
                
                // Get target group (new status) from NewGroupColumnValue
                string newStatus = newGroupColumnValueProperty.GetValue(e)?.ToString() ?? "";
                
                // Check if status actually changed
                if (task.Status == newStatus)
                    return; // No change needed
                
                // Parse status and priority strings to enums
                if (!Enum.TryParse<TaskStatus>(task.Status, out var currentStatus))
                    currentStatus = TaskStatus.Pending;
                    
                if (!Enum.TryParse<TaskStatus>(newStatus, out var newStatusEnum))
                    newStatusEnum = TaskStatus.Pending;
                    
                if (!Enum.TryParse<Priority>(task.Priority, out var priority))
                    priority = Priority.Medium;
                
                // Update task status via service
                var updateDto = new UpdateTaskDto
                {
                    TaskId = task.TaskId,
                    TaskName = task.TaskName,
                    Description = task.Description,
                    ProjectId = task.ProjectId,
                    AssignedUserId = task.AssignedToUserId,
                    StartDate = task.StartDate,
                    DueDate = task.DueDate,
                    Priority = priority,
                    Status = newStatusEnum
                };
                
                await _taskService.UpdateTaskAsync(task.TaskId, updateDto);
                
                // Update local data
                task.Status = newStatus;
                
                // Refresh to show updated counts
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Failed to update task status: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Try to cancel drag operation
                try 
                { 
                    var cancelProperty = e.GetType().GetProperty("Cancel");
                    if (cancelProperty != null)
                        cancelProperty.SetValue(e, true);
                } 
                catch { /* Ignore */ }
            }
        }

        /// <summary>
        /// Handles tile double-click event
        /// </summary>
        private void TileViewKanban_ItemDoubleClick(object sender, TileViewItemClickEventArgs e)
        {
            var task = tileViewKanban.GetFocusedRow() as TaskDto;
            if (task != null)
            {
                OpenTaskForEdit(task.TaskId);
            }
        }

        /// <summary>
        /// Customizes tile appearance based on task properties
        /// </summary>
        private void TileViewKanban_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            var task = tileViewKanban.GetRow(e.RowHandle) as TaskDto;
            if (task == null) return;
            
            // Get priority color (Modern palette)
            Color priorityColor = task.Priority switch
            {
                "Critical" => Color.FromArgb(239, 68, 68),    // Red-500
                "High" => Color.FromArgb(251, 146, 60),        // Orange-400
                "Medium" => Color.FromArgb(14, 165, 233),      // Sky-500
                "Low" => Color.FromArgb(16, 185, 129),         // Emerald-500
                _ => Color.FromArgb(161, 161, 161)             // Gray-400
            };
            
            // Apply border color
            e.Item.AppearanceItem.Normal.BorderColor = priorityColor;
            e.Item.AppearanceItem.Normal.Options.UseBorderColor = true;
            
            // Create only 2 elements to prevent overlap
            var elements = new List<DevExpress.XtraEditors.TileItemElement>();

            // Top: Task Name + Project (combined)
            var titleText = task.TaskName;
            if (!string.IsNullOrEmpty(task.ProjectName))
            {
                titleText += $"\n{task.ProjectName}";
            }
            
            var titleElement = new DevExpress.XtraEditors.TileItemElement();
            titleElement.Text = "  " + titleText;
            titleElement.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            titleElement.Appearance.Normal.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            titleElement.Appearance.Normal.ForeColor = Color.White;
            titleElement.Appearance.Normal.Options.UseFont = true;
            titleElement.Appearance.Normal.Options.UseForeColor = true;
            elements.Add(titleElement);

            // Bottom: Priority + Due Date
            var bottomText = task.Priority;
            if (task.DueDate.HasValue)
            {
                bottomText += "  •  " + task.DueDate.Value.ToString("dd MMM");
            }
            
            var bottomElement = new DevExpress.XtraEditors.TileItemElement();
            bottomElement.Text = "  " + bottomText;
            bottomElement.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;
            bottomElement.Appearance.Normal.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
            bottomElement.Appearance.Normal.ForeColor = priorityColor;
            bottomElement.Appearance.Normal.Options.UseFont = true;
            bottomElement.Appearance.Normal.Options.UseForeColor = true;
            elements.Add(bottomElement);

            e.Item.Elements.Clear();
            foreach (var element in elements)
            {
                e.Item.Elements.Add(element);
            }
        }

        /// <summary>
        /// Opens task detail form for editing
        /// </summary>
        private void OpenTaskForEdit(int taskId)
        {
            var detailControl = Program.ServiceProvider.GetRequiredService<TaskDetailControl>();
            detailControl.LoadTaskForEdit(taskId);
            ((FrmDashboard)this.ParentForm).LoadContent(detailControl);
        }

        #endregion
      

    }
}