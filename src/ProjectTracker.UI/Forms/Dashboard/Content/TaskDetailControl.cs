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
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskStatus = ProjectTracker.Core.Enums.TaskStatus;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    public partial class TaskDetailControl : UserControl
    {
        private readonly ITaskService _taskService;
        private readonly IProjectService _projectService;
        private readonly ITeamService _teamService;
        private readonly IGitHubAnalyticsService? _analyticsService;

        private int? _editingTaskId = null; // Edit mode indicator
        private List<TeamMemberDto>? _teamMembers; // Cache for team members

        public TaskDetailControl(ITaskService taskService, IProjectService projectService, ITeamService teamService, IGitHubAnalyticsService? analyticsService = null)
        {
            InitializeComponent();
            _taskService = taskService;
            _projectService = projectService;
            _teamService = teamService;
            _analyticsService = analyticsService;

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
            
            // Project selection changed - load team members
            lueProject.EditValueChanged += LueProject_EditValueChanged;

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
                // ROL BAZLI PROJE LİSTESİ - Sadece task eklenebilir projeler
                IEnumerable<ProjectDto> projects;
                if (SessionManager.IsAdmin)
                {
                    projects = await _projectService.GetAllAsync();
                }
                else
                {
                    projects = await _projectService.GetUserProjectsAsync(SessionManager.CurrentUserId);
                }
                
                // Sadece aktif projeleri filtrele (Completed ve Cancelled hariç)
                var activeProjects = projects.Where(p => 
                    p.Status != Core.Enums.ProjectStatus.Completed && 
                    p.Status != Core.Enums.ProjectStatus.Cancelled)
                    .OrderBy(p => p.ProjectName)
                    .ToList();
                
                lueProject.Properties.DataSource = activeProjects;
                lueProject.Properties.DisplayMember = "ProjectName";
                lueProject.Properties.ValueMember = "ProjectId";

                // Configure Project LookUpEdit columns
                lueProject.Properties.Columns.Clear();
                lueProject.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProjectName", "Project Name", 250));
                lueProject.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Status", "Status", 80));
                lueProject.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TeamName", "Team", 120));
                lueProject.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EndDate", "Due Date", 100) 
                { 
                    FormatString = "dd MMM yyyy", 
                    FormatType = DevExpress.Utils.FormatType.DateTime 
                });

                // Configure Assignee LookUpEdit columns
                lueAssignee.Properties.Columns.Clear();
                lueAssignee.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserName", "Name", 180));
                lueAssignee.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Email", "Email", 200));
                lueAssignee.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoleName", "Role", 100));
                lueAssignee.Properties.DisplayMember = "UserName";
                lueAssignee.Properties.ValueMember = "UserId";
                lueAssignee.Properties.NullText = "Select assignee...";
                lueAssignee.Properties.PopupWidth = 500;
                lueAssignee.Properties.ShowFooter = false;
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error loading data: {ex.Message}");
            }
        }

        /// <summary>
        /// When project is selected, load team members for assignee dropdown
        /// </summary>
        private async void LueProject_EditValueChanged(object sender, EventArgs e)
        {
            await LoadAssigneesForProjectAsync();
        }

        /// <summary>
        /// Load team members for the selected project
        /// </summary>
        private async System.Threading.Tasks.Task LoadAssigneesForProjectAsync()
        {
            try
            {
                if (lueProject.EditValue == null)
                {
                    lueAssignee.Properties.DataSource = null;
                    lueAssignee.EditValue = null;
                    return;
                }

                int projectId = Convert.ToInt32(lueProject.EditValue);
                
                // Get project to find team
                var project = await _projectService.GetProjectByIdAsync(projectId);
                if (project == null || project.TeamId == 0)
                {
                    lueAssignee.Properties.DataSource = null;
                    lueAssignee.EditValue = null;
                    return;
                }

                // Get team members
                _teamMembers = (await _teamService.GetTeamMembersAsync(project.TeamId)).ToList();
                
                lueAssignee.Properties.DataSource = _teamMembers;
                
                // If editing and assignee was set, keep it
                if (_editingTaskId.HasValue && lueAssignee.EditValue != null)
                {
                    // Verify assignee is still in team
                    var assigneeId = Convert.ToInt32(lueAssignee.EditValue);
                    if (!_teamMembers.Any(m => m.UserId == assigneeId))
                    {
                        lueAssignee.EditValue = null;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading assignees: {ex.Message}");
                lueAssignee.Properties.DataSource = null;
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
                btnSave.Text = "Update Task";

                var task = await _taskService.GetTaskByIdAsync(taskId);

                txtTaskName.Text = task.TaskName;
                txtDescription.Text = task.Description;
                lueProject.EditValue = task.ProjectId;
                
                // Load assignees for this project first
                await LoadAssigneesForProjectAsync();
                
                // Then set the assignee
                lueAssignee.EditValue = task.AssignedToUserId;
                
                dateStart.DateTime = task.StartDate ?? DateTime.Today;
                dateDue.DateTime = task.DueDate ?? DateTime.Today.AddDays(7);
                
                // Parse string to enum for ComboBoxes
                if (Enum.TryParse<TaskStatus>(task.Status, out var taskStatus))
                    cmbStatus.SelectedItem = taskStatus;
                    
                if (Enum.TryParse<Priority>(task.Priority, out var taskPriority))
                    cmbPriority.SelectedItem = taskPriority;

                // Load related commits panel
                await LoadRelatedCommitsAsync(taskId);
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error loading task: {ex.Message}");
            }
        }

        /// <summary>
        /// Load commits linked to this task
        /// </summary>
        private async System.Threading.Tasks.Task LoadRelatedCommitsAsync(int taskId)
        {
            if (_analyticsService == null)
            {
                pnlRelatedCommits.Visible = false;
                return;
            }

            try
            {
                var commits = await _analyticsService.GetCommitsByTaskAsync(taskId);
                var commitList = commits?.ToList() ?? new List<GitCommitDto>();

                pnlCommitsList.Controls.Clear();

                if (commitList.Count == 0)
                {
                    lblNoCommits.Visible = true;
                    lblCommitsSummary.Text = "No commits linked";
                }
                else
                {
                    lblNoCommits.Visible = false;

                    int totalAdditions = 0;
                    int totalDeletions = 0;

                    foreach (var commit in commitList.Take(20)) // Max 20 commits
                    {
                        var card = CreateCommitCard(commit);
                        pnlCommitsList.Controls.Add(card);
                        totalAdditions += commit.Additions;
                        totalDeletions += commit.Deletions;
                    }

                    lblCommitsSummary.Text = $"Total: {commitList.Count} commits, +{totalAdditions} / -{totalDeletions} lines";
                }

                pnlRelatedCommits.Visible = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading commits: {ex.Message}");
                pnlRelatedCommits.Visible = false;
            }
        }

        /// <summary>
        /// Create a visual card for a commit
        /// </summary>
        private Panel CreateCommitCard(GitCommitDto commit)
        {
            var card = new Panel
            {
                Width = 350,
                Height = 70,
                BackColor = Color.FromArgb(30, 42, 58),
                Margin = new Padding(0, 0, 0, 8),
                Padding = new Padding(10)
            };

            // SHA label (short hash)
            var lblSha = new Label
            {
                Text = $"[{commit.ShortSha}]",
                Font = new Font("Consolas", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(91, 141, 239),
                Location = new Point(10, 8),
                AutoSize = true
            };

            // Message label
            var message = commit.Message?.Length > 40 
                ? commit.Message.Substring(0, 40) + "..." 
                : commit.Message ?? "No message";
            var lblMessage = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(248, 250, 252),
                Location = new Point(85, 8),
                Size = new Size(255, 20),
                AutoEllipsis = true
            };

            // Author and date
            var timeAgo = GetTimeAgo(commit.CommitDate);
            var lblAuthor = new Label
            {
                Text = $"{commit.AuthorName ?? "Unknown"} - {timeAgo}",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(10, 30),
                AutoSize = true
            };

            // Lines changed
            var lblLines = new Label
            {
                Text = $"+{commit.Additions} / -{commit.Deletions}",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(10, 48),
                AutoSize = true
            };

            // Color indicator for additions/deletions
            var addColor = commit.Additions > 0 ? Color.FromArgb(34, 197, 94) : Color.FromArgb(100, 116, 139);
            var delColor = commit.Deletions > 0 ? Color.FromArgb(239, 68, 68) : Color.FromArgb(100, 116, 139);

            var lblAdd = new Label
            {
                Text = $"+{commit.Additions}",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = addColor,
                Location = new Point(280, 48),
                AutoSize = true
            };

            var lblDel = new Label
            {
                Text = $"-{commit.Deletions}",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = delColor,
                Location = new Point(315, 48),
                AutoSize = true
            };

            card.Controls.AddRange(new Control[] { lblSha, lblMessage, lblAuthor, lblAdd, lblDel });

            // Hover effect
            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(40, 52, 68);
            card.MouseLeave += (s, e) => card.BackColor = Color.FromArgb(30, 42, 58);

            return card;
        }

        /// <summary>
        /// Get human-readable time ago string
        /// </summary>
        private string GetTimeAgo(DateTime date)
        {
            var span = DateTime.UtcNow - date;

            if (span.TotalMinutes < 1) return "just now";
            if (span.TotalMinutes < 60) return $"{(int)span.TotalMinutes}m ago";
            if (span.TotalHours < 24) return $"{(int)span.TotalHours}h ago";
            if (span.TotalDays < 7) return $"{(int)span.TotalDays}d ago";
            if (span.TotalDays < 30) return $"{(int)(span.TotalDays / 7)}w ago";
            return date.ToString("MMM dd");
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
