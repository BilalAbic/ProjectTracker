using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    /// <summary>
    /// Projects content UserControl - Displays all projects with filtering
    /// </summary>
    public partial class ProjectsContent : UserControl
    {
        #region Fields

        private readonly IProjectService _projectService;
        private List<ProjectDto> _allProjects;
        private List<ProjectDto> _filteredProjects;

        // Repository item for progress bar
        private RepositoryItemProgressBar _progressBarRepository;

        // Repository item for action buttons
        private RepositoryItemButtonEdit _actionButtonsRepository;

        #endregion


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ProjectsContent class
        /// </summary>
        /// <param name="projectService">Project service instance</param>
        public ProjectsContent(IProjectService projectService)
        {
            InitializeComponent();
            _projectService = projectService;

            // Initialize
            SetupGrid();
            SetupEventHandlers();

            // Load data
            _ = LoadProjectsAsync();
        }

        /// <summary>
        /// Parameterless constructor for Designer
        /// </summary>
        public ProjectsContent()
        {
            InitializeComponent();
        }

        #endregion


        #region Setup Methods

        /// <summary>
        /// Setup grid columns and appearance
        /// </summary>
        private void SetupGrid()
        {
            // Get GridView
            var gridView = grdProjects.MainView as GridView;
            if (gridView == null) return;

            // Setup Progress Bar repository
            _progressBarRepository = new RepositoryItemProgressBar
            {
                Minimum = 0,
                Maximum = 100,
                ShowTitle = true,
                PercentView = true
            };
            _progressBarRepository.Appearance.BackColor = Color.FromArgb(42, 42, 42);
            _progressBarRepository.Appearance.ForeColor = Color.FromArgb(255, 77, 0);

            // Assign to CompletionPercentage column
            var progressColumn = gridView.Columns["CompletionPercentage"];
            if (progressColumn != null)
            {
                progressColumn.ColumnEdit = _progressBarRepository;
            }

            // Setup Action Buttons repository
            _actionButtonsRepository = new RepositoryItemButtonEdit
            {
                TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
            };
            _actionButtonsRepository.Buttons.Clear();
            _actionButtonsRepository.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton(
                DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            { Caption = "✏️", Width = 30 });
            _actionButtonsRepository.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton(
                DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            { Caption = "🗑️", Width = 30 });
            _actionButtonsRepository.ButtonClick += ActionButtonsRepository_ButtonClick;

            // Assign to Actions column
            var actionsColumn = gridView.Columns["Actions"];
            if (actionsColumn != null)
            {
                actionsColumn.ColumnEdit = _actionButtonsRepository;
            }

            // Custom draw for Status column
            gridView.CustomDrawCell += gridView1_CustomDrawCell;

            // Row click event
            gridView.RowClick += gridView1_RowClick;
        }

        /// <summary>
        /// Setup all event handlers
        /// </summary>
        private void SetupEventHandlers()
        {
            // New Project button
            btnNewProject.Click += btnNewProject_Click;

            // Search text changed
            txtSearch.EditValueChanged += txtSearch_EditValueChanged;

            // Filter dropdowns
            cmbStatusFilter.SelectedIndexChanged += Filter_Changed;
            cmbPriorityFilter.SelectedIndexChanged += Filter_Changed;

            // Clear filters
            btnClearFilters.Click += btnClearFilters_Click;

            // Refresh
            btnRefresh.Click += async (s, e) => await LoadProjectsAsync();

            // Hover effects
            SetupHoverEffects();
        }

        /// <summary>
        /// Setup button hover effects
        /// </summary>
        private void SetupHoverEffects()
        {
            // New Project button
            btnNewProject.MouseEnter += (s, e) =>
            {
                btnNewProject.Appearance.BackColor = Color.FromArgb(255, 100, 50);
            };
            btnNewProject.MouseLeave += (s, e) =>
            {
                btnNewProject.Appearance.BackColor = Color.FromArgb(255, 77, 0);
            };

            // Clear filters button
            btnClearFilters.MouseEnter += (s, e) =>
            {
                btnClearFilters.Appearance.ForeColor = Color.FromArgb(255, 255, 255);
            };
            btnClearFilters.MouseLeave += (s, e) =>
            {
                btnClearFilters.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            };

            // Refresh button
            btnRefresh.MouseEnter += (s, e) =>
            {
                btnRefresh.Appearance.ForeColor = Color.FromArgb(255, 255, 255);
            };
            btnRefresh.MouseLeave += (s, e) =>
            {
                btnRefresh.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            };
        }

        #endregion

        #region Data Loading

        /// <summary>
        /// Load all projects from database
        /// </summary>
        private async Task LoadProjectsAsync()
        {
            try
            {
                // Show loading
                Cursor = Cursors.WaitCursor;

                // Get projects
                var projects = await _projectService.GetAllAsync();
                _allProjects = projects.ToList();

                // Apply filters
                ApplyFilters();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Error loading projects: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Apply current filters to projects list
        /// </summary>
        private void ApplyFilters()
        {
            if (_allProjects == null) return;

            // Create a new list to avoid reference issues
            _filteredProjects = _allProjects.ToList();

            // Search filter
            string searchText = txtSearch.Text?.Trim().ToLower() ?? "";
            if (!string.IsNullOrEmpty(searchText))
            {
                _filteredProjects = _filteredProjects
                    .Where(p => p.ProjectName.ToLower().Contains(searchText) ||
                               (p.Description?.ToLower().Contains(searchText) ?? false))
                    .ToList();
            }

            // Status filter
            string statusFilter = cmbStatusFilter.Text;
            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All Status")
            {
                if (Enum.TryParse<ProjectStatus>(statusFilter.Replace(" ", ""), out var status))
                {
                    _filteredProjects = _filteredProjects
                        .Where(p => p.Status == status)
                        .ToList();
                }
            }

            // Priority filter
            string priorityFilter = cmbPriorityFilter.Text;
            if (!string.IsNullOrEmpty(priorityFilter) && priorityFilter != "All Priority")
            {
                if (Enum.TryParse<Priority>(priorityFilter, out var priority))
                {
                    _filteredProjects = _filteredProjects
                        .Where(p => p.Priority == priority)
                        .ToList();
                }
            }

            // Clear and rebind to grid to avoid tracking issues
            grdProjects.DataSource = null;
            grdProjects.DataSource = _filteredProjects.ToList();

            // Update record count
            UpdateRecordCount();
        }

        /// <summary>
        /// Update the record count label
        /// </summary>
        private void UpdateRecordCount()
        {
            int showing = _filteredProjects?.Count ?? 0;
            int total = _allProjects?.Count ?? 0;
            lblRecordCount.Text = $"Showing {showing} of {total} projects";
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// New Project button click
        /// </summary>
        private void btnNewProject_Click(object sender, EventArgs e)
        {
            OpenProjectDetail(null); // null = new project
        }

        /// <summary>
        /// Search text changed
        /// </summary>
        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        /// <summary>
        /// Clear filters button click
        /// </summary>
        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbStatusFilter.SelectedIndex = 0; // "All Status"
            cmbPriorityFilter.SelectedIndex = 0; // "All Priority"
            ApplyFilters();
        }

        /// <summary>
        /// Grid row click event
        /// </summary>
        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            // Double click to edit
            if (e.Clicks == 2)
            {
                var gridView = sender as GridView;
                var project = gridView?.GetFocusedRow() as ProjectDto;
                if (project != null)
                {
                    OpenProjectDetail(project);
                }
            }
        }

        /// <summary>
        /// Filter dropdown changed
        /// </summary>
        private void Filter_Changed(object? sender, EventArgs e)
        {
            ApplyFilters();
        }

        /// <summary>
        /// Action button click (Edit/Delete)
        /// </summary>
        private void ActionButtonsRepository_ButtonClick(object? sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var gridView = grdProjects.MainView as GridView;
            if (gridView == null) return;

            // Get selected project
            var project = gridView.GetFocusedRow() as ProjectDto;
            if (project == null) return;

            // Check which button was clicked
            int buttonIndex = _actionButtonsRepository.Buttons.IndexOf(e.Button);

            if (buttonIndex == 0) // Edit
            {
                OpenProjectDetail(project);
            }
            else if (buttonIndex == 1) // Delete
            {
                DeleteProject(project);
            }
        }

        #endregion


        #region Custom Draw

        /// <summary>
        /// Custom draw cell for Status column (colored badges)
        /// </summary>
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName != "Status") return;

            var project = (sender as GridView)?.GetRow(e.RowHandle) as ProjectDto;
            if (project == null) return;

            // Draw custom status badge
            e.Handled = true;

            // Get status color
            Color badgeColor = GetStatusColor(project.Status);

            // Draw background
            using (var brush = new SolidBrush(Color.FromArgb(21, 21, 21)))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            // Draw badge
            int badgeWidth = 86;
            int badgeHeight = 22;
            int badgeX = e.Bounds.X + (e.Bounds.Width - badgeWidth) / 2;
            int badgeY = e.Bounds.Y + (e.Bounds.Height - badgeHeight) / 2;

            var badgeRect = new Rectangle(badgeX, badgeY, badgeWidth, badgeHeight);

            using (var brush = new SolidBrush(Color.FromArgb(40, badgeColor)))
            {
                // Rounded rectangle background
                e.Graphics.FillRectangle(brush, badgeRect);
            }

            // Draw circle indicator
            int circleSize = 8;
            int circleX = badgeX + 8;
            int circleY = badgeY + (badgeHeight - circleSize) / 2;

            using (var brush = new SolidBrush(badgeColor))
            {
                e.Graphics.FillEllipse(brush, circleX, circleY, circleSize, circleSize);
            }

            // Draw text
            string statusText = project.Status.ToString();
            using (var brush = new SolidBrush(badgeColor))
            using (var font = new Font("Segoe UI", 8f, FontStyle.Bold))
            {
                var textRect = new Rectangle(circleX + circleSize + 4, badgeY, badgeWidth - circleSize - 16, badgeHeight);
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(statusText, font, brush, textRect, format);
            }
        }

        /// <summary>
        /// Get color for project status
        /// </summary>
        private Color GetStatusColor(ProjectStatus status)
        {
            return status switch
            {
                ProjectStatus.Planned => Color.FromArgb(255, 184, 0),   // Yellow
                ProjectStatus.Active => Color.FromArgb(0, 208, 132),     // Green
                ProjectStatus.OnHold => Color.FromArgb(128, 128, 128),   // Gray
                ProjectStatus.Completed => Color.FromArgb(0, 102, 255),  // Blue
                ProjectStatus.Cancelled => Color.FromArgb(255, 77, 77),  // Red
                _ => Color.FromArgb(161, 161, 161)                       // Default gray
            };
        }

        #endregion


        #region Project Operations

        /// <summary>
        /// Open project detail form for add/edit
        /// </summary>
        /// <param name="project">Project to edit, or null for new project</param>
        private void OpenProjectDetail(ProjectDto? project)
        {
            var detailControl = new ProjectDetailControl(_projectService, project);

            detailControl.ProjectSaved += async (s, e) =>
            {
                await LoadProjectsAsync();
            };

            var parentForm = this.FindForm() as FrmDashboard;
            parentForm?.LoadContent(detailControl);
        }

        /// <summary>
        /// Delete a project
        /// </summary>
        private async void DeleteProject(ProjectDto project)
        {
            // Confirm deletion
            var result = XtraMessageBox.Show(
                $"Are you sure you want to delete project '{project.ProjectName}'?\n\nThis action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                await _projectService.DeleteProjectAsync(project.ProjectId);

                XtraMessageBox.Show(
                    "Project deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Reload
                await LoadProjectsAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Error deleting project: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
