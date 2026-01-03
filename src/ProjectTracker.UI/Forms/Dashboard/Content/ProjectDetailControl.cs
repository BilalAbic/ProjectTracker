using DevExpress.XtraEditors;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Enums;
using ProjectTracker.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    /// <summary>
    /// Project detail control for creating/editing projects
    /// </summary>
    public partial class ProjectDetailControl : UserControl
    {
        #region Fields

        private readonly IProjectService _projectService;
        private readonly ITeamService _teamService;
        private readonly ITaskService? _taskService;
        private ProjectDto? _currentProject;
        private bool _isEditMode;
        private List<TeamDto> _userTeams = new();

        #endregion

        #region Events

        /// <summary>
        /// Event raised when a project is saved
        /// </summary>
        public event EventHandler? ProjectSaved;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ProjectDetailControl class
        /// </summary>
        public ProjectDetailControl(IProjectService projectService, ITeamService teamService, ProjectDto? project = null, ITaskService? taskService = null)
        {
            InitializeComponent();
            _projectService = projectService;
            _teamService = teamService;
            _taskService = taskService;
            _currentProject = project;
            _isEditMode = project != null;

            // YETKİ KONTROLÜ: Developer proje oluşturamaz/güncelleyemez
            if (SessionManager.IsDeveloper)
            {
                this.Load += (s, e) =>
                {
                    FormStyleHelper.ShowWarning("You don't have permission to create/edit projects.");
                    NavigateBack();
                };
                return;
            }

            SetupEventHandlers();
            SetupForm();
            SetupLayoutView();
            
            // Load teams after form is loaded
            this.Load += async (s, e) => 
            {
                await LoadTeamsAsync();
                if (_isEditMode && _currentProject != null)
                {
                    await LoadProjectTasksAsync(_currentProject.ProjectId);
                }
            };
        }

        /// <summary>
        /// Parameterless constructor for Designer
        /// </summary>
        public ProjectDetailControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Setup Methods

        private void SetupEventHandlers()
        {
            btnBack.Click += btnBack_Click;
            btnCancel.Click += btnCancel_Click;
            btnSave.Click += btnSave_Click;
            SetupHoverEffects();
        }

        private void SetupForm()
        {
            // Status dropdown
            cmbStatus.Properties.Items.AddRange(new[] { "Planned", "Active", "OnHold", "Completed", "Cancelled" });

            // Priority dropdown
            cmbPriority.Properties.Items.AddRange(new[] { "Low", "Medium", "High", "Critical" });

            // Team LookUpEdit setup
            lueManager.Properties.DisplayMember = "TeamName";
            lueManager.Properties.ValueMember = "TeamId";
            lueManager.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TeamName", "Team Name"));
            lueManager.Properties.ShowHeader = false;

            if (_isEditMode && _currentProject != null)
            {
                lblTitle.Text = "📁 Edit Project";
                lblSubtitle.Text = $"Editing: {_currentProject.ProjectName}";

                txtProjectName.Text = _currentProject.ProjectName;
                memoDescription.Text = _currentProject.Description;
                dateStartDate.DateTime = _currentProject.StartDate;
                dateEndDate.DateTime = _currentProject.EndDate ?? DateTime.MinValue;
                cmbStatus.Text = _currentProject.Status.ToString();
                cmbPriority.Text = _currentProject.Priority.ToString();
                spinBudget.Value = _currentProject.Budget ?? 0;
                // TeamId will be set after teams are loaded
            }
            else
            {
                lblTitle.Text = "📁 New Project";
                lblSubtitle.Text = "Fill in the project details below";
                dateStartDate.DateTime = DateTime.Today;
                cmbStatus.SelectedIndex = 0;
                cmbPriority.SelectedIndex = 1;
            }
        }

        private async System.Threading.Tasks.Task LoadTeamsAsync()
        {
            try
            {
                // Load teams based on user role
                if (SessionManager.IsAdmin)
                {
                    var teams = await _teamService.GetAllTeamsAsync();
                    _userTeams = teams.ToList();
                }
                else
                {
                    var teams = await _teamService.GetUserTeamsAsync();
                    _userTeams = teams.ToList();
                }

                lueManager.Properties.DataSource = _userTeams;

                // Set selected team if editing
                if (_isEditMode && _currentProject != null && _currentProject.TeamId > 0)
                {
                    lueManager.EditValue = _currentProject.TeamId;
                }
                else if (_userTeams.Count == 1)
                {
                    // Auto-select if user has only one team
                    lueManager.EditValue = _userTeams[0].TeamId;
                }
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error loading teams: {ex.Message}");
            }
        }

        private void SetupHoverEffects()
        {
            btnBack.MouseEnter += (s, e) => btnBack.Appearance.ForeColor = Color.White;
            btnBack.MouseLeave += (s, e) => btnBack.Appearance.ForeColor = ColorPalette.TextSecondary;

            btnCancel.MouseEnter += (s, e) => btnCancel.Appearance.BackColor = ColorPalette.BackgroundSlateLight;
            btnCancel.MouseLeave += (s, e) => btnCancel.Appearance.BackColor = ColorPalette.BorderSlate;

            btnSave.MouseEnter += (s, e) => btnSave.Appearance.BackColor = ColorPalette.AccentSkyBlue;
            btnSave.MouseLeave += (s, e) => btnSave.Appearance.BackColor = ColorPalette.AccentRoyalBlue;
        }

        /// <summary>
        /// Setup LayoutView for task cards with custom drawing
        /// </summary>
        private void SetupLayoutView()
        {
            // No longer using LayoutView, using FlowLayoutPanel instead
        }

        /// <summary>
        /// Load tasks for the current project
        /// </summary>
        private async System.Threading.Tasks.Task LoadProjectTasksAsync(int projectId)
        {
            if (_taskService == null)
            {
                pnlProjectTasks.Visible = false;
                return;
            }

            try
            {
                var tasks = await _taskService.GetTasksByProjectsAsync(new[] { projectId });
                var taskList = tasks?.ToList() ?? new List<TaskDto>();

                pnlTasksList.Controls.Clear();

                if (taskList.Count == 0)
                {
                    lblNoTasks.Visible = true;
                    pnlTasksList.Visible = false;
                    lblTasksSummary.Text = "No tasks in this project";
                }
                else
                {
                    lblNoTasks.Visible = false;
                    pnlTasksList.Visible = true;

                    foreach (var task in taskList.Take(15)) // Max 15 tasks
                    {
                        var card = CreateTaskCard(task);
                        pnlTasksList.Controls.Add(card);
                    }

                    // Summary
                    var completed = taskList.Count(t => t.Status == "Done");
                    var inProgress = taskList.Count(t => t.Status == "InProgress");
                    lblTasksSummary.Text = $"{taskList.Count} tasks ({completed} done, {inProgress} in progress)";
                }

                pnlProjectTasks.Visible = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading tasks: {ex.Message}");
                pnlProjectTasks.Visible = false;
            }
        }

        /// <summary>
        /// Create a visual card for a task
        /// </summary>
        private Panel CreateTaskCard(TaskDto task)
        {
            var card = new Panel
            {
                Width = 405,
                Height = 85,
                BackColor = Color.FromArgb(30, 42, 58),
                Margin = new Padding(0, 0, 0, 8),
                Padding = new Padding(12)
            };

            // Task name
            var lblName = new Label
            {
                Text = task.TaskName?.Length > 35 ? task.TaskName.Substring(0, 35) + "..." : task.TaskName,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(248, 250, 252),
                Location = new Point(12, 10),
                AutoSize = true
            };

            // Status badge
            var statusColor = GetStatusColor(task.Status ?? "");
            var lblStatus = new Label
            {
                Text = task.Status ?? "Unknown",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = statusColor,
                BackColor = Color.FromArgb(30, statusColor),
                Location = new Point(12, 35),
                AutoSize = true,
                Padding = new Padding(6, 2, 6, 2)
            };

            // Priority
            var priorityColor = GetPriorityColor(task.Priority ?? "");
            var lblPriority = new Label
            {
                Text = task.Priority ?? "",
                Font = new Font("Segoe UI", 8F),
                ForeColor = priorityColor,
                Location = new Point(100, 37),
                AutoSize = true
            };

            // Assignee
            var lblAssignee = new Label
            {
                Text = task.AssignedToUserName ?? "Unassigned",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(12, 60),
                AutoSize = true
            };

            // Due date
            var dueText = task.DueDate.HasValue ? task.DueDate.Value.ToString("dd MMM") : "-";
            var lblDue = new Label
            {
                Text = dueText,
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(350, 60),
                AutoSize = true
            };

            card.Controls.AddRange(new Control[] { lblName, lblStatus, lblPriority, lblAssignee, lblDue });

            // Hover effect
            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(40, 52, 68);
            card.MouseLeave += (s, e) => card.BackColor = Color.FromArgb(30, 42, 58);

            return card;
        }

        private Color GetStatusColor(string status)
        {
            return status switch
            {
                "ToDo" => Color.FromArgb(100, 116, 139),
                "InProgress" => Color.FromArgb(59, 130, 246),
                "InReview" => Color.FromArgb(168, 85, 247),
                "Done" => Color.FromArgb(34, 197, 94),
                "Blocked" => Color.FromArgb(239, 68, 68),
                _ => Color.FromArgb(100, 116, 139)
            };
        }

        private Color GetPriorityColor(string priority)
        {
            return priority switch
            {
                "Critical" => Color.FromArgb(239, 68, 68),
                "High" => Color.FromArgb(249, 115, 22),
                "Medium" => Color.FromArgb(234, 179, 8),
                "Low" => Color.FromArgb(34, 197, 94),
                _ => Color.FromArgb(100, 116, 139)
            };
        }

        #endregion


        #region Event Handlers

        private void btnBack_Click(object? sender, EventArgs e) => NavigateBack();

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            if (FormStyleHelper.ShowQuestion("Are you sure you want to cancel?"))
                NavigateBack();
        }

        private async void btnSave_Click(object? sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                Cursor = Cursors.WaitCursor;
                btnSave.Enabled = false;

                if (_isEditMode)
                    await UpdateProjectAsync();
                else
                    await CreateProjectAsync();

                ProjectSaved?.Invoke(this, EventArgs.Empty);

                FormStyleHelper.ShowSuccess(_isEditMode ? "Project updated!" : "Project created!");

                NavigateBack();
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
                btnSave.Enabled = true;
            }
        }

        #endregion

        #region Validation

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtProjectName.Text))
            {
                FormStyleHelper.ShowWarning("Project name is required.");
                txtProjectName.Focus();
                return false;
            }

            if (lueManager.EditValue == null || Convert.ToInt32(lueManager.EditValue) <= 0)
            {
                FormStyleHelper.ShowWarning("Please select a team for this project.");
                lueManager.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region CRUD Operations

        private async Task CreateProjectAsync()
        {
            var dto = new CreateProjectDto
            {
                ProjectName = txtProjectName.Text.Trim(),
                Description = memoDescription.Text?.Trim(),
                StartDate = dateStartDate.DateTime,
                EndDate = dateEndDate.DateTime == DateTime.MinValue ? null : dateEndDate.DateTime,
                Status = Enum.Parse<ProjectStatus>(cmbStatus.Text),
                Priority = Enum.Parse<Priority>(cmbPriority.Text),
                Budget = (decimal)spinBudget.Value,
                CreatedByUserId = SessionManager.CurrentUserId,
                TeamId = Convert.ToInt32(lueManager.EditValue)
            };

            await _projectService.CreateProjectAsync(dto);
        }

        private async Task UpdateProjectAsync()
        {
            if (_currentProject == null) return;

            var dto = new UpdateProjectDto
            {
                ProjectId = _currentProject.ProjectId,
                ProjectName = txtProjectName.Text.Trim(),
                Description = memoDescription.Text?.Trim(),
                StartDate = dateStartDate.DateTime,
                EndDate = dateEndDate.DateTime == DateTime.MinValue ? null : dateEndDate.DateTime,
                Status = Enum.Parse<ProjectStatus>(cmbStatus.Text),
                Priority = Enum.Parse<Priority>(cmbPriority.Text),
                Budget = (decimal)spinBudget.Value,
                TeamId = Convert.ToInt32(lueManager.EditValue)
            };

            await _projectService.UpdateProjectAsync(_currentProject.ProjectId, dto);
        }

        #endregion

        #region Navigation

        private void NavigateBack()
        {
            var parentForm = this.FindForm() as FrmDashboard;
            if (parentForm != null)
            {
                var projectsContent = new ProjectsContent(_projectService, _teamService, _taskService);
                parentForm.LoadContent(projectsContent);
            }
        }

        #endregion
    }
}
