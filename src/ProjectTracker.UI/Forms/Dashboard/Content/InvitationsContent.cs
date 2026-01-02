using DevExpress.XtraEditors;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
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
    /// Invitations content control - Team invitation management
    /// </summary>
    public partial class InvitationsContent : UserControl
    {
        #region Fields
        
        private readonly IInvitationService _invitationService;
        private readonly ITeamService _teamService;
        private List<TeamInvitationDto>? _invitations;
        private int? _selectedTeamId;
        private string? _selectedTeamName;
        
        #endregion
        
        #region Constructor
        
        public InvitationsContent(IInvitationService invitationService, ITeamService teamService)
        {
            InitializeComponent();
            _invitationService = invitationService;
            _teamService = teamService;
            
            LoadRoles();
            SetupEventHandlers();
        }
        
        public InvitationsContent()
        {
            InitializeComponent();
        }
        
        #endregion
        
        #region Public Methods
        
        /// <summary>
        /// Set team context for invitations
        /// </summary>
        public void SetTeamContext(int teamId, string teamName)
        {
            _selectedTeamId = teamId;
            _selectedTeamName = teamName;
            LoadInvitationsForTeamAsync(teamId);
        }
        
        #endregion
        
        #region Setup
        
        private void LoadRoles()
        {
            cmbRole.Properties.Items.Clear();
            cmbRole.Properties.Items.AddRange(new object[] {
                "Admin", "Project Manager", "Developer", "Observer"
            });
            cmbRole.SelectedIndex = 2; // Developer
        }
        
        private void SetupEventHandlers()
        {
            btnSend.Click += BtnSend_Click;
            btnSendInvitation.Click += (s, e) => txtEmail.Focus();
        }
        
        #endregion
        
        #region Data Loading
        
        private async void LoadInvitationsForTeamAsync(int teamId)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                
                _invitations = (await _invitationService.GetTeamInvitationsAsync(teamId)).ToList();
                RenderInvitations();
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error loading invitations: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        
        private async void LoadInvitationsAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                
                if (_selectedTeamId.HasValue)
                {
                    _invitations = (await _invitationService.GetTeamInvitationsAsync(_selectedTeamId.Value)).ToList();
                }
                else
                {
                    var activeTeam = await _teamService.GetActiveTeamAsync();
                    if (activeTeam == null)
                    {
                        FormStyleHelper.ShowWarning("No active team selected");
                        return;
                    }
                    
                    _selectedTeamId = activeTeam.TeamId;
                    _selectedTeamName = activeTeam.TeamName;
                    _invitations = (await _invitationService.GetTeamInvitationsAsync(activeTeam.TeamId)).ToList();
                }
                
                RenderInvitations();
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error loading invitations: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        
        #endregion
        
        #region Rendering
        
        private void RenderInvitations()
        {
            flowInvitations.Controls.Clear();
            
            if (_invitations == null)
            {
                lblRecordCount.Text = "Showing 0 pending invitations";
                return;
            }
            
            var pendingInvitations = _invitations
                .Where(i => i.Status == Core.Enums.InvitationStatus.Pending || i.IsExpired)
                .ToList();
            
            foreach (var invitation in pendingInvitations)
            {
                var card = CreateInvitationCard(invitation);
                flowInvitations.Controls.Add(card);
            }
            
            lblRecordCount.Text = $"Showing {pendingInvitations.Count} pending invitations";
        }
        
        private PanelControl CreateInvitationCard(TeamInvitationDto invitation)
        {
            var card = new PanelControl
            {
                Width = 980,
                Height = 140,
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple,
                Margin = new Padding(0, 0, 0, 15)
            };
            card.Appearance.BackColor = ColorPalette.BackgroundSlateDark;
            card.Appearance.BorderColor = ColorPalette.BorderSlate;
            
            // Email
            var lblEmail = new LabelControl
            {
                Text = $"📧 {invitation.Email}",
                Location = new Point(15, 15),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(950, 24)
            };
            lblEmail.Appearance.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblEmail.Appearance.ForeColor = Color.White;
            card.Controls.Add(lblEmail);
            
            // Role
            var lblRole = new LabelControl
            {
                Text = $"Role: {invitation.ProposedRole}",
                Location = new Point(15, 45),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(950, 20)
            };
            lblRole.Appearance.ForeColor = ColorPalette.TextSecondary;
            card.Controls.Add(lblRole);
            
            // Sent & Expiry
            var daysAgo = (DateTime.Now - invitation.SentAt).Days;
            var expiryInfo = invitation.IsExpired 
                ? "Expired" 
                : $"Expires in {(invitation.ExpiresAt - DateTime.Now).Days} days";
            
            var lblTime = new LabelControl
            {
                Text = $"Sent: {daysAgo} days ago • {expiryInfo}",
                Location = new Point(15, 70),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(950, 20)
            };
            lblTime.Appearance.ForeColor = ColorPalette.TextSecondary;
            card.Controls.Add(lblTime);
            
            // Status badge
            var (statusText, statusColor) = GetStatusDisplay(invitation);
            var lblStatus = new LabelControl
            {
                Text = statusText,
                Location = new Point(15, 95),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(200, 20)
            };
            lblStatus.Appearance.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblStatus.Appearance.ForeColor = statusColor;
            card.Controls.Add(lblStatus);
            
            // Invited by
            var lblInvitedBy = new LabelControl
            {
                Text = $"Invited by: {invitation.InvitedByName}",
                Location = new Point(230, 95),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(300, 20)
            };
            lblInvitedBy.Appearance.ForeColor = ColorPalette.TextSecondary;
            card.Controls.Add(lblInvitedBy);
            
            // Action buttons
            int buttonX = 550;
            
            // Copy Link
            if (!invitation.IsExpired)
            {
                var btnCopy = new SimpleButton
                {
                    Text = "📋 Copy Link",
                    Location = new Point(buttonX, 90),
                    Size = new Size(120, 28)
                };
                btnCopy.Appearance.BackColor = ColorPalette.BorderSlate;
                btnCopy.Click += (s, e) => CopyInvitationLink(invitation.Token);
                card.Controls.Add(btnCopy);
                buttonX += 130;
            }
            
            // Resend
            var btnResend = new SimpleButton
            {
                Text = "🔄 Resend",
                Location = new Point(buttonX, 90),
                Size = new Size(100, 28)
            };
            btnResend.Appearance.BackColor = ColorPalette.AccentRoyalBlue;
            btnResend.Click += async (s, e) => await ResendInvitation(invitation.InvitationId);
            card.Controls.Add(btnResend);
            buttonX += 110;
            
            // Cancel
            var btnCancel = new SimpleButton
            {
                Text = "❌ Cancel",
                Location = new Point(buttonX, 90),
                Size = new Size(100, 28)
            };
            btnCancel.Appearance.BackColor = ColorPalette.DangerRed;
            btnCancel.Click += async (s, e) => await CancelInvitation(invitation.InvitationId);
            card.Controls.Add(btnCancel);
            
            return card;
        }
        
        private (string text, Color color) GetStatusDisplay(TeamInvitationDto invitation)
        {
            if (invitation.IsExpired)
                return ("⏱️ Expired", ColorPalette.TextSecondary);
            
            return invitation.Status switch
            {
                Core.Enums.InvitationStatus.Pending => ("🟡 Pending", ColorPalette.WarningAmber),
                Core.Enums.InvitationStatus.Accepted => ("✅ Accepted", ColorPalette.SuccessGreen),
                Core.Enums.InvitationStatus.Declined => ("❌ Declined", ColorPalette.DangerRed),
                _ => ("❓ Unknown", ColorPalette.TextSecondary)
            };
        }
        
        #endregion
        
        #region Actions
        
        private async void BtnSend_Click(object sender, EventArgs e)
        {
            if (!ValidateInvitation())
                return;
            
            try
            {
                Cursor = Cursors.WaitCursor;
                
                int teamId;
                if (_selectedTeamId.HasValue)
                {
                    teamId = _selectedTeamId.Value;
                }
                else
                {
                    var activeTeam = await _teamService.GetActiveTeamAsync();
                    if (activeTeam == null)
                    {
                        FormStyleHelper.ShowWarning("No active team selected");
                        return;
                    }
                    teamId = activeTeam.TeamId;
                }
                
                var invitationDto = new TeamInvitationDto
                {
                    TeamId = teamId,
                    Email = txtEmail.Text.Trim(),
                    ProposedRole = (Core.Enums.TeamRole)Enum.Parse(typeof(Core.Enums.TeamRole), cmbRole.Text.Replace(" ", ""))
                };
                
                await _invitationService.SendInvitationAsync(invitationDto);
                
                FormStyleHelper.ShowSuccess($"Invitation sent to {invitationDto.Email}!");
                
                txtEmail.Text = string.Empty;
                LoadInvitationsAsync();
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error sending invitation: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        
        private void CopyInvitationLink(string token)
        {
            var link = $"https://yourapp.com/accept-invitation?token={token}";
            Clipboard.SetText(link);
            FormStyleHelper.ShowSuccess("Invitation link copied to clipboard!");
        }
        
        private async Task ResendInvitation(int invitationId)
        {
            try
            {
                await _invitationService.ResendInvitationAsync(invitationId);
                FormStyleHelper.ShowSuccess("Invitation resent successfully!");
                LoadInvitationsAsync();
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error resending invitation: {ex.Message}");
            }
        }
        
        private async Task CancelInvitation(int invitationId)
        {
            if (FormStyleHelper.ShowQuestion("Cancel this invitation?"))
            {
                try
                {
                    await _invitationService.CancelInvitationAsync(invitationId);
                    FormStyleHelper.ShowSuccess("Invitation cancelled");
                    LoadInvitationsAsync();
                }
                catch (Exception ex)
                {
                    FormStyleHelper.ShowError($"Error: {ex.Message}");
                }
            }
        }
        
        private bool ValidateInvitation()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                FormStyleHelper.ShowWarning("Email is required");
                return false;
            }
            
            if (!txtEmail.Text.Contains("@"))
            {
                FormStyleHelper.ShowWarning("Invalid email format");
                return false;
            }
            
            return true;
        }
        
        #endregion
    }
}
