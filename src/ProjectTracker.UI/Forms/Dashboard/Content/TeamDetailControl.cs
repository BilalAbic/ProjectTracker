using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.UI.Helpers;
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
            ApplyGroupControlStyling();
        }

        /// <summary>
        /// Parameterless constructor for Designer
        /// </summary>
        public TeamDetailControl()
        {
            InitializeComponent();
            ApplyGroupControlStyling();
        }

        /// <summary>
        /// Apply dark theme styling to GroupControls
        /// </summary>
        private void ApplyGroupControlStyling()
        {
            // Fix GroupControl content area background using LookAndFeel
            grpTeamInfo.LookAndFeel.UseDefaultLookAndFeel = false;
            grpTeamInfo.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            
            grpStatistics.LookAndFeel.UseDefaultLookAndFeel = false;
            grpStatistics.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
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
                    FormStyleHelper.ShowError("Team not found");
                    return;
                }

                // Populate form
                txtTeamName.Text = team.TeamName;
                txtDescription.Text = team.Description;

                // Update UI for edit mode
                lblTitle.Text = "✏️ Edit Team";
                btnSave.Text = "💾 Update";
                btnDelete.Visible = true;
                
                // Enable action buttons in edit mode
                btnViewMembers.Enabled = true;
                btnViewInvitations.Enabled = true;

                // Update statistics
                lblStats.Text = $"📊 Team Overview:\r\n\r\n" +
                               $"• Members: {team.MemberCount}\r\n" +
                               $"• Active Projects: {team.ProjectCount}\r\n" +
                               $"• Created: {team.CreatedAt:dd MMM yyyy}\r\n" +
                               $"• Owner: {team.OwnerName}";
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error loading team: {ex.Message}");
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
                    FormStyleHelper.ShowWarning("Team name is required");
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

                    FormStyleHelper.ShowSuccess("Team updated successfully!");
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

                    FormStyleHelper.ShowSuccess("Team created successfully!");
                }

                // Navigate back to teams list
                btnBack_Click(sender, e);
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error saving team: {ex.Message}");
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

                if (!FormStyleHelper.ShowQuestion("Are you sure you want to delete this team?\nThis action cannot be undone."))
                    return;

                Cursor = Cursors.WaitCursor;
                btnDelete.Enabled = false;

                await _teamService.DeleteTeamAsync(_editTeamId.Value);

                FormStyleHelper.ShowSuccess("Team deleted successfully!");

                // Navigate back
                btnBack_Click(sender, e);
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error deleting team: {ex.Message}");
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
                FormStyleHelper.ShowInfo("Please save the team first");
                return;
            }

            try
            {
                var membersContent = Program.ServiceProvider.GetRequiredService<TeamMembersContent>();
                ((FrmDashboard)this.ParentForm)?.LoadContent(membersContent);
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error opening members: {ex.Message}");
            }
        }

        /// <summary>
        /// View Invitations button click
        /// </summary>
        private void btnViewInvitations_Click(object sender, EventArgs e)
        {
            if (!_editTeamId.HasValue)
            {
                FormStyleHelper.ShowInfo("Please save the team first");
                return;
            }

            try
            {
                var invitationsContent = Program.ServiceProvider.GetRequiredService<InvitationsContent>();
                ((FrmDashboard)this.ParentForm)?.LoadContent(invitationsContent);
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error opening invitations: {ex.Message}");
            }
        }
    }
}
