using DevExpress.XtraEditors;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Enums;
using System;
using System.Drawing;
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
        private ProjectDto? _currentProject;
        private bool _isEditMode;

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
        public ProjectDetailControl(IProjectService projectService, ProjectDto? project = null)
        {
            InitializeComponent();
            _projectService = projectService;
            _currentProject = project;
            _isEditMode = project != null;

            SetupEventHandlers();
            SetupForm();
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

        private void SetupHoverEffects()
        {
            btnBack.MouseEnter += (s, e) => btnBack.Appearance.ForeColor = Color.White;
            btnBack.MouseLeave += (s, e) => btnBack.Appearance.ForeColor = Color.FromArgb(161, 161, 161);

            btnCancel.MouseEnter += (s, e) => btnCancel.Appearance.BackColor = Color.FromArgb(60, 60, 60);
            btnCancel.MouseLeave += (s, e) => btnCancel.Appearance.BackColor = Color.FromArgb(42, 42, 42);

            btnSave.MouseEnter += (s, e) => btnSave.Appearance.BackColor = Color.FromArgb(255, 100, 50);
            btnSave.MouseLeave += (s, e) => btnSave.Appearance.BackColor = Color.FromArgb(255, 77, 0);
        }

        #endregion


        #region Event Handlers

        private void btnBack_Click(object? sender, EventArgs e) => NavigateBack();

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            var result = XtraMessageBox.Show(
                "Are you sure you want to cancel?",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes) NavigateBack();
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

                XtraMessageBox.Show(
                    _isEditMode ? "Project updated!" : "Project created!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                NavigateBack();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                XtraMessageBox.Show("Project name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProjectName.Focus();
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
                CreatedByUserId = 1 // TODO: Get current user ID
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
                Budget = (decimal)spinBudget.Value
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
                var projectsContent = new ProjectsContent(_projectService);
                parentForm.LoadContent(projectsContent);
            }
        }

        #endregion
    }
}
