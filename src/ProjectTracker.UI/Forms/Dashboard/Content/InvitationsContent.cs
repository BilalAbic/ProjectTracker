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
            
            // Update title to show team name
            lblTitle.Text = $"📧   {teamName} - Invitations";
            lblSubtitle.Text = $"Invite members to {teamName}";
            
            LoadInvitationsForTeamAsync(teamId);
        }
        
        #endregion
        
        #region Setup
        
        private void LoadRoles()
        {
            cmbRole.Properties.Items.Clear();
            // Admin role removed - Admin should be assigned by system admin, not via invitation
            cmbRole.Properties.Items.AddRange(new object[] {
                "Project Manager", "Developer", "Observer"
            });
            cmbRole.SelectedIndex = 1; // Developer as default
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
                Width = 1050,
                Height = 120,
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple,
                Margin = new Padding(0, 0, 0, 12)
            };
            card.Appearance.BackColor = ColorPalette.BackgroundSlateDark;
            card.Appearance.BorderColor = ColorPalette.BorderSlate;
            card.Appearance.Options.UseBackColor = true;
            card.Appearance.Options.UseBorderColor = true;
            
            // Email - Primary info
            var lblEmail = new LabelControl
            {
                Text = $"📧  {invitation.Email}",
                Location = new Point(20, 15),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(500, 24)
            };
            lblEmail.Appearance.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblEmail.Appearance.ForeColor = ColorPalette.TextPrimary;
            lblEmail.Appearance.Options.UseFont = true;
            lblEmail.Appearance.Options.UseForeColor = true;
            card.Controls.Add(lblEmail);
            
            // Role badge
            var lblRole = new LabelControl
            {
                Text = $"👤 {invitation.ProposedRole}",
                Location = new Point(20, 45),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(150, 20)
            };
            lblRole.Appearance.Font = new Font("Segoe UI", 9.5F);
            lblRole.Appearance.ForeColor = ColorPalette.AccentLightBlue;
            lblRole.Appearance.Options.UseFont = true;
            lblRole.Appearance.Options.UseForeColor = true;
            card.Controls.Add(lblRole);
            
            // Sent & Expiry info
            var daysAgo = (DateTime.Now - invitation.SentAt).Days;
            var sentText = daysAgo == 0 ? "Today" : daysAgo == 1 ? "Yesterday" : $"{daysAgo} days ago";
            var expiryInfo = invitation.IsExpired 
                ? "⏱️ Expired" 
                : $"⏳ Expires in {(invitation.ExpiresAt - DateTime.Now).Days} days";
            
            var lblTime = new LabelControl
            {
                Text = $"📅 Sent: {sentText}  •  {expiryInfo}",
                Location = new Point(180, 45),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(350, 20)
            };
            lblTime.Appearance.Font = new Font("Segoe UI", 9F);
            lblTime.Appearance.ForeColor = ColorPalette.TextSecondary;
            lblTime.Appearance.Options.UseFont = true;
            lblTime.Appearance.Options.UseForeColor = true;
            card.Controls.Add(lblTime);
            
            // Status badge
            var (statusText, statusColor) = GetStatusDisplay(invitation);
            var lblStatus = new LabelControl
            {
                Text = statusText,
                Location = new Point(20, 80),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(120, 22)
            };
            lblStatus.Appearance.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStatus.Appearance.ForeColor = statusColor;
            lblStatus.Appearance.Options.UseFont = true;
            lblStatus.Appearance.Options.UseForeColor = true;
            card.Controls.Add(lblStatus);
            
            // Invited by
            var lblInvitedBy = new LabelControl
            {
                Text = $"👤 Invited by: {invitation.InvitedByName ?? "Unknown"}",
                Location = new Point(150, 80),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(300, 22)
            };
            lblInvitedBy.Appearance.Font = new Font("Segoe UI", 9F);
            lblInvitedBy.Appearance.ForeColor = ColorPalette.TextTertiary;
            lblInvitedBy.Appearance.Options.UseFont = true;
            lblInvitedBy.Appearance.Options.UseForeColor = true;
            card.Controls.Add(lblInvitedBy);
            
            // Action buttons - right aligned
            int buttonX = 700;
            
            // Copy Link (only if not expired)
            if (!invitation.IsExpired)
            {
                var btnCopy = CreateActionButton("📋 Copy Link", ColorPalette.BorderSlate, ColorPalette.TextPrimary);
                btnCopy.Location = new Point(buttonX, 75);
                btnCopy.Size = new Size(110, 30);
                btnCopy.Click += (s, e) => CopyInvitationLink(invitation.Token);
                card.Controls.Add(btnCopy);
                buttonX += 120;
            }
            
            // Resend
            var btnResend = CreateActionButton("🔄 Resend", ColorPalette.AccentRoyalBlue, Color.White);
            btnResend.Location = new Point(buttonX, 75);
            btnResend.Size = new Size(100, 30);
            btnResend.Click += async (s, e) => await ResendInvitation(invitation.InvitationId);
            card.Controls.Add(btnResend);
            buttonX += 110;
            
            // Cancel
            var btnCancel = CreateActionButton("❌ Cancel", ColorPalette.DangerRed, Color.White);
            btnCancel.Location = new Point(buttonX, 75);
            btnCancel.Size = new Size(100, 30);
            btnCancel.Click += async (s, e) => await CancelInvitation(invitation.InvitationId);
            card.Controls.Add(btnCancel);
            
            return card;
        }
        
        private SimpleButton CreateActionButton(string text, Color backColor, Color foreColor)
        {
            var btn = new SimpleButton
            {
                Text = text
            };
            btn.Appearance.BackColor = backColor;
            btn.Appearance.ForeColor = foreColor;
            btn.Appearance.Font = new Font("Segoe UI", 9F);
            btn.Appearance.Options.UseBackColor = true;
            btn.Appearance.Options.UseForeColor = true;
            btn.Appearance.Options.UseFont = true;
            return btn;
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
