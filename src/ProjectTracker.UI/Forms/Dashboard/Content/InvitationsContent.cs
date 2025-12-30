using DevExpress.XtraEditors;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
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
        
        #endregion
        
        #region Constructor
        
        public InvitationsContent(IInvitationService invitationService, ITeamService teamService)
        {
            InitializeComponent();
            _invitationService = invitationService;
            _teamService = teamService;
            
            LoadRoles();
            LoadInvitationsAsync();
            SetupEventHandlers();
        }
        
        public InvitationsContent()
        {
            InitializeComponent();
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
        
        private async void LoadInvitationsAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                
                var activeTeam = await _teamService.GetActiveTeamAsync();
                if (activeTeam == null)
                {
                    XtraMessageBox.Show("No active team selected", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                _invitations = (await _invitationService.GetTeamInvitationsAsync(activeTeam.TeamId)).ToList();
                RenderInvitations();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading invitations: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            card.Appearance.BackColor = Color.FromArgb(21, 21, 21);
            card.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            
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
            lblRole.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
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
            lblTime.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
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
            lblInvitedBy.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
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
                btnCopy.Appearance.BackColor = Color.FromArgb(42, 42, 42);
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
            btnResend.Appearance.BackColor = Color.FromArgb(255, 77, 0);
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
            btnCancel.Appearance.BackColor = Color.FromArgb(255, 77, 77);
            btnCancel.Click += async (s, e) => await CancelInvitation(invitation.InvitationId);
            card.Controls.Add(btnCancel);
            
            return card;
        }
        
        private (string text, Color color) GetStatusDisplay(TeamInvitationDto invitation)
        {
            if (invitation.IsExpired)
                return ("⏱️ Expired", Color.FromArgb(161, 161, 161));
            
            return invitation.Status switch
            {
                Core.Enums.InvitationStatus.Pending => ("🟡 Pending", Color.FromArgb(255, 184, 0)),
                Core.Enums.InvitationStatus.Accepted => ("✅ Accepted", Color.FromArgb(0, 208, 132)),
                Core.Enums.InvitationStatus.Declined => ("❌ Declined", Color.FromArgb(255, 77, 77)),
                _ => ("❓ Unknown", Color.Gray)
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
                
                var activeTeam = await _teamService.GetActiveTeamAsync();
                if (activeTeam == null)
                {
                    XtraMessageBox.Show("No active team selected", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                var invitationDto = new TeamInvitationDto
                {
                    TeamId = activeTeam.TeamId,
                    Email = txtEmail.Text.Trim(),
                    ProposedRole = (Core.Enums.TeamRole)Enum.Parse(typeof(Core.Enums.TeamRole), cmbRole.Text.Replace(" ", ""))
                };
                
                await _invitationService.SendInvitationAsync(invitationDto);
                
                XtraMessageBox.Show($"Invitation sent to {invitationDto.Email}!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                txtEmail.Text = string.Empty;
                LoadInvitationsAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error sending invitation: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            XtraMessageBox.Show("Invitation link copied to clipboard!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private async Task ResendInvitation(int invitationId)
        {
            try
            {
                await _invitationService.ResendInvitationAsync(invitationId);
                XtraMessageBox.Show("Invitation resent successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInvitationsAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error resending invitation: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private async Task CancelInvitation(int invitationId)
        {
            var result = XtraMessageBox.Show("Cancel this invitation?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    await _invitationService.CancelInvitationAsync(invitationId);
                    XtraMessageBox.Show("Invitation cancelled", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInvitationsAsync();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private bool ValidateInvitation()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                XtraMessageBox.Show("Email is required", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (!txtEmail.Text.Contains("@"))
            {
                XtraMessageBox.Show("Invalid email format", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            return true;
        }
        
        #endregion
    }
}
