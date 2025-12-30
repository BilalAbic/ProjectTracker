using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using System;
using System.Windows.Forms;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    /// <summary>
    /// Team detail control - Create and edit teams
    /// </summary>
    public partial class TeamDetailControl : UserControl
    {
        private readonly ITeamService _teamService;
        private int? _editTeamId;

        /// <summary>
        /// Constructor with dependency injection
        /// </summary>
        public TeamDetailControl(ITeamService teamService)
        {
            InitializeComponent();
            _teamService = teamService;
        }

        /// <summary>
        /// Parameterless constructor for Designer
        /// </summary>
        public TeamDetailControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load team for editing
        /// </summary>
        public async void LoadTeamForEdit(int teamId)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _editTeamId = teamId;

                // Load team data
                var team = await _teamService.GetTeamByIdAsync(teamId);
                if (team == null)
                {
                    XtraMessageBox.Show("Team not found", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Populate form
                txtTeamName.Text = team.TeamName;
                txtDescription.Text = team.Description;

                // Update UI
                lblTitle.Text = "✏️ Edit Team";
                btnSave.Text = "💾 Update Team";
                btnDelete.Visible = true;
                grpStatistics.Visible = true;

                // Update statistics
                lblStats.Text = $"📊 Team Overview:\n" +
                               $"• Members: {team.MemberCount}\n" +
                               $"• Active Projects: {team.ProjectCount}\n" +
                               $"• Created: {team.CreatedAt:dd MMM yyyy}\n" +
                               $"• Owner: {team.OwnerName}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading team: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Back button click
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            var teamsContent = Program.ServiceProvider.GetRequiredService<TeamsContent>();
            ((FrmDashboard)this.ParentForm)?.LoadContent(teamsContent);
        }

        /// <summary>
        /// Save button click
        /// </summary>
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(txtTeamName.Text))
                {
                    XtraMessageBox.Show("Team name is required", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTeamName.Focus();
                    return;
                }

                Cursor = Cursors.WaitCursor;
                btnSave.Enabled = false;

                if (_editTeamId.HasValue)
                {
                    // Update existing team
                    var updateDto = new UpdateTeamDto
                    {
                        TeamId = _editTeamId.Value,
                        TeamName = txtTeamName.Text.Trim(),
                        Description = txtDescription.Text.Trim()
                    };

                    await _teamService.UpdateTeamAsync(updateDto);

                    XtraMessageBox.Show("Team updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Create new team
                    var createDto = new CreateTeamDto
                    {
                        TeamName = txtTeamName.Text.Trim(),
                        Description = txtDescription.Text.Trim()
                    };

                    await _teamService.CreateTeamAsync(createDto);

                    XtraMessageBox.Show("Team created successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Navigate back to teams list
                btnBack_Click(sender, e);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error saving team: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnSave.Enabled = true;
            }
        }

        /// <summary>
        /// Cancel button click
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnBack_Click(sender, e);
        }

        /// <summary>
        /// Delete button click
        /// </summary>
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_editTeamId.HasValue) return;

                var result = XtraMessageBox.Show(
                    "Are you sure you want to delete this team? This action cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes) return;

                Cursor = Cursors.WaitCursor;
                btnDelete.Enabled = false;

                await _teamService.DeleteTeamAsync(_editTeamId.Value);

                XtraMessageBox.Show("Team deleted successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Navigate back
                btnBack_Click(sender, e);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error deleting team: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnDelete.Enabled = true;
            }
        }
        /// <summary>
        /// View Members button click
        /// </summary>
        private void btnViewMembers_Click(object sender, EventArgs e)
        {
            if (!_editTeamId.HasValue)
            {
                XtraMessageBox.Show("Please save the team first", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var membersContent = Program.ServiceProvider.GetRequiredService<TeamMembersContent>();
                ((FrmDashboard)this.ParentForm)?.LoadContent(membersContent);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error opening members: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// View Invitations button click
        /// </summary>
        private void btnViewInvitations_Click(object sender, EventArgs e)
        {
            if (!_editTeamId.HasValue)
            {
                XtraMessageBox.Show("Please save the team first", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var invitationsContent = Program.ServiceProvider.GetRequiredService<InvitationsContent>();
                ((FrmDashboard)this.ParentForm)?.LoadContent(invitationsContent);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error opening invitations: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
