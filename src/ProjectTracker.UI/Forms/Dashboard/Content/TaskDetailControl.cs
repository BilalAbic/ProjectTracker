using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Enums;
using ProjectTracker.UI.Forms.Dashboard;
using ProjectTracker.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskStatus = ProjectTracker.Core.Enums.TaskStatus;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    public partial class TaskDetailControl : UserControl
    {
        private readonly ITaskService _taskService;
        private readonly IProjectService _projectService;
        // private readonly IUserService _userService; // Will be added when User service is implemented

        private int? _editingTaskId = null; // Edit mode indicator

        public TaskDetailControl(ITaskService taskService, IProjectService projectService)
        {
            InitializeComponent();
            _taskService = taskService;
            _projectService = projectService;

            // Fill ComboBox Enums
            cmbStatus.Properties.Items.AddRange(Enum.GetValues(typeof(TaskStatus)));
            cmbPriority.Properties.Items.AddRange(Enum.GetValues(typeof(Priority)));

            // Set default values
            cmbStatus.SelectedIndex = 0;
            cmbPriority.SelectedIndex = 2; // Medium

            // Events
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnBack.Click += BtnCancel_Click;

            this.Load += async (s, e) => await LoadDropdownsAsync();
        }

        public TaskDetailControl()
        {
            InitializeComponent();
        }

        private async System.Threading.Tasks.Task LoadDropdownsAsync()
        {
            try
            {
                // ROL BAZLI PROJE LİSTESİ
                IEnumerable<ProjectDto> projects;
                if (SessionManager.IsAdmin)
                {
                    projects = await _projectService.GetAllAsync();
                }
                else
                {
                    projects = await _projectService.GetUserProjectsAsync(SessionManager.CurrentUserId);
                }
                
                lueProject.Properties.DataSource = projects;
                lueProject.Properties.DisplayMember = "ProjectName";
                lueProject.Properties.ValueMember = "ProjectId";

                // Configure Project LookUpEdit columns
                lueProject.Properties.Columns.Clear();
                lueProject.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProjectName", "Project Name", 250));
                lueProject.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Status", "Status", 80));
                lueProject.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CreatedByUserName", "Manager", 150));
                lueProject.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EndDate", "Due Date", 100) 
                { 
                    FormatString = "dd MMM yyyy", 
                    FormatType = DevExpress.Utils.FormatType.DateTime 
                });

                // Load Assignee (Users) - will be implemented when User service is available
                // var users = await _userService.GetAllUsersAsync();
                // lueAssignee.Properties.DataSource = users;
                // lueAssignee.Properties.DisplayMember = "FullName";
                // lueAssignee.Properties.ValueMember = "UserId";
                lueAssignee.Properties.NullText = "Unassigned";
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error loading data: {ex.Message}");
            }
        }

        /// <summary>
        /// Load task data for editing mode
        /// </summary>
        public async void LoadTaskForEdit(int taskId)
        {
            try
            {
                _editingTaskId = taskId;
                lblTitle.Text = "Edit Task";
                btnSave.Text = "💾 Update Task";

                var task = await _taskService.GetTaskByIdAsync(taskId);

                txtTaskName.Text = task.TaskName;
                txtDescription.Text = task.Description;
                lueProject.EditValue = task.ProjectId;
                lueAssignee.EditValue = task.AssignedToUserId;
                dateStart.DateTime = task.StartDate ?? DateTime.Today;
                dateDue.DateTime = task.DueDate ?? DateTime.Today.AddDays(7);
                
                // Parse string to enum for ComboBoxes
                if (Enum.TryParse<TaskStatus>(task.Status, out var taskStatus))
                    cmbStatus.SelectedItem = taskStatus;
                    
                if (Enum.TryParse<Priority>(task.Priority, out var taskPriority))
                    cmbPriority.SelectedItem = taskPriority;
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error loading task: {ex.Message}");
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtTaskName.Text))
            {
                FormStyleHelper.ShowWarning("Task Name is required!");
                txtTaskName.Focus();
                return;
            }

            if (lueProject.EditValue == null)
            {
                FormStyleHelper.ShowWarning("Please select a project!");
                lueProject.Focus();
                return;
            }

            if (dateStart.DateTime == DateTime.MinValue || dateDue.DateTime == DateTime.MinValue)
            {
                FormStyleHelper.ShowWarning("Please select start and due dates!");
                return;
            }

            if (dateDue.DateTime < dateStart.DateTime)
            {
                FormStyleHelper.ShowWarning("Due date cannot be earlier than start date!");
                return;
            }

            try
            {
                if (_editingTaskId.HasValue)
                {
                    // Update existing task
                    var updateDto = new UpdateTaskDto
                    {
                        TaskId = _editingTaskId.Value,
                        TaskName = txtTaskName.Text.Trim(),
                        Description = txtDescription.Text?.Trim(),
                        ProjectId = (int)lueProject.EditValue,
                        AssignedUserId = (int?)lueAssignee.EditValue,
                        StartDate = dateStart.EditValue != null ? dateStart.DateTime : (DateTime?)null,
                        DueDate = dateDue.EditValue != null ? dateDue.DateTime : (DateTime?)null,
                        Status = (TaskStatus)cmbStatus.SelectedItem,
                        Priority = (Priority)cmbPriority.SelectedItem
                    };

                    await _taskService.UpdateTaskAsync(_editingTaskId.Value, updateDto);
                    FormStyleHelper.ShowSuccess("Task updated successfully!");
                }
                else
                {
                    // Create new task
                    var createDto = new CreateTaskDto
                    {
                        TaskName = txtTaskName.Text.Trim(),
                        Description = txtDescription.Text?.Trim(),
                        ProjectId = (int)lueProject.EditValue,
                        AssignedUserId = (int?)lueAssignee.EditValue,
                        StartDate = dateStart.EditValue != null ? dateStart.DateTime : (DateTime?)null,
                        DueDate = dateDue.EditValue != null ? dateDue.DateTime : (DateTime?)null,
                        Status = (TaskStatus)cmbStatus.SelectedItem,
                        Priority = (Priority)cmbPriority.SelectedItem
                    };

                    await _taskService.CreateTaskAsync(createDto);
                    FormStyleHelper.ShowSuccess("Task created successfully!");
                }

                // Navigate back
                GoBack();
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error saving task: {ex.Message}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void GoBack()
        {
            var tasksContent = Program.ServiceProvider.GetRequiredService<TasksContent>();
            ((FrmDashboard)this.ParentForm).LoadContent(tasksContent);
        }
    }
}
