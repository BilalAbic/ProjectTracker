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
    /// My Invitations content - Shows pending team invitations for current user
    /// </summary>
    public partial class MyInvitationsContent : UserControl
    {
        private readonly IInvitationService _invitationService;
        private readonly IUserService _userService;
        private List<TeamInvitationDto>? _invitations;

        public MyInvitationsContent(IInvitationService invitationService, IUserService userService)
        {
            InitializeComponent();
            _invitationService = invitationService;
            _userService = userService;
            
            this.Load += MyInvitationsContent_Load;
        }

        public MyInvitationsContent()
        {
            InitializeComponent();
        }

        private async void MyInvitationsContent_Load(object? sender, EventArgs e)
        {
            await LoadInvitationsAsync();
        }

        private async Task LoadInvitationsAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                
                // Get current user's email
                var currentUser = await _userService.GetUserByIdAsync(SessionManager.CurrentUserId);
                if (currentUser == null || string.IsNullOrEmpty(currentUser.Email))
                {
                    lblRecordCount.Text = "Unable to load invitations";
                    return;
                }

                _invitations = (await _invitationService.GetUserPendingInvitationsAsync(currentUser.Email)).ToList();
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

        private void RenderInvitations()
        {
            flowInvitations.Controls.Clear();

            if (_invitations == null || !_invitations.Any())
            {
                // Show empty state
                var emptyPanel = CreateEmptyState();
                flowInvitations.Controls.Add(emptyPanel);
                lblRecordCount.Text = "No pending invitations";
                return;
            }

            foreach (var invitation in _invitations)
            {
                var card = CreateInvitationCard(invitation);
                flowInvitations.Controls.Add(card);
            }

            lblRecordCount.Text = $"You have {_invitations.Count} pending invitation(s)";
        }

        private Panel CreateEmptyState()
        {
            var panel = new Panel
            {
                Width = 1050,
                Height = 300,
                BackColor = ColorPalette.BackgroundDeepNavy
            };

            var lblEmoji = new Label
            {
                Text = "📭",
                Font = new Font("Segoe UI", 48F),
                ForeColor = ColorPalette.TextTertiary,
                AutoSize = false,
                Size = new Size(1050, 80),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 60)
            };
            panel.Controls.Add(lblEmoji);

            var lblMessage = new Label
            {
                Text = "No Pending Invitations",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = ColorPalette.TextSecondary,
                AutoSize = false,
                Size = new Size(1050, 30),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 150)
            };
            panel.Controls.Add(lblMessage);

            var lblSubMessage = new Label
            {
                Text = "When someone invites you to join their team, it will appear here.",
                Font = new Font("Segoe UI", 10F),
                ForeColor = ColorPalette.TextTertiary,
                AutoSize = false,
                Size = new Size(1050, 25),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 185)
            };
            panel.Controls.Add(lblSubMessage);

            return panel;
        }

        private PanelControl CreateInvitationCard(TeamInvitationDto invitation)
        {
            var card = new PanelControl
            {
                Width = 1050,
                Height = 160,
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple,
                Margin = new Padding(0, 0, 0, 15)
            };
            card.Appearance.BackColor = ColorPalette.BackgroundSlateDark;
            card.Appearance.BorderColor = ColorPalette.BorderSlate;
            card.Appearance.Options.UseBackColor = true;
            card.Appearance.Options.UseBorderColor = true;

            // Team icon and name
            var lblTeamIcon = new LabelControl
            {
                Text = "👥",
                Location = new Point(20, 20),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(40, 40)
            };
            lblTeamIcon.Appearance.Font = new Font("Segoe UI", 24F);
            card.Controls.Add(lblTeamIcon);

            var lblTeamName = new LabelControl
            {
                Text = invitation.TeamName,
                Location = new Point(70, 20),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(500, 28)
            };
            lblTeamName.Appearance.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblTeamName.Appearance.ForeColor = ColorPalette.TextPrimary;
            lblTeamName.Appearance.Options.UseFont = true;
            lblTeamName.Appearance.Options.UseForeColor = true;
            card.Controls.Add(lblTeamName);

            // Role badge
            var lblRole = new LabelControl
            {
                Text = $"Role: {invitation.ProposedRole}",
                Location = new Point(70, 52),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(200, 22)
            };
            lblRole.Appearance.Font = new Font("Segoe UI", 10F);
            lblRole.Appearance.ForeColor = ColorPalette.AccentLightBlue;
            lblRole.Appearance.Options.UseFont = true;
            lblRole.Appearance.Options.UseForeColor = true;
            card.Controls.Add(lblRole);

            // Invited by
            var lblInvitedBy = new LabelControl
            {
                Text = $"👤 Invited by: {invitation.InvitedByName}",
                Location = new Point(70, 80),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(300, 22)
            };
            lblInvitedBy.Appearance.Font = new Font("Segoe UI", 9.5F);
            lblInvitedBy.Appearance.ForeColor = ColorPalette.TextSecondary;
            lblInvitedBy.Appearance.Options.UseFont = true;
            lblInvitedBy.Appearance.Options.UseForeColor = true;
            card.Controls.Add(lblInvitedBy);

            // Expiry info
            var expiresIn = (invitation.ExpiresAt - DateTime.Now).Days;
            var expiryColor = expiresIn <= 2 ? ColorPalette.WarningOrange : ColorPalette.TextTertiary;
            var lblExpiry = new LabelControl
            {
                Text = $"⏳ Expires in {expiresIn} days ({invitation.ExpiresAt:dd MMM yyyy})",
                Location = new Point(70, 108),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(400, 22)
            };
            lblExpiry.Appearance.Font = new Font("Segoe UI", 9F);
            lblExpiry.Appearance.ForeColor = expiryColor;
            lblExpiry.Appearance.Options.UseFont = true;
            lblExpiry.Appearance.Options.UseForeColor = true;
            card.Controls.Add(lblExpiry);

            // Action buttons - right side
            var btnAccept = new SimpleButton
            {
                Text = "✅ Accept",
                Location = new Point(780, 55),
                Size = new Size(120, 40),
                Tag = invitation.Token
            };
            btnAccept.Appearance.BackColor = ColorPalette.SuccessGreen;
            btnAccept.Appearance.ForeColor = Color.White;
            btnAccept.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAccept.Appearance.Options.UseBackColor = true;
            btnAccept.Appearance.Options.UseForeColor = true;
            btnAccept.Appearance.Options.UseFont = true;
            btnAccept.Click += async (s, e) => await AcceptInvitation(invitation.Token);
            card.Controls.Add(btnAccept);

            var btnDecline = new SimpleButton
            {
                Text = "❌ Decline",
                Location = new Point(910, 55),
                Size = new Size(120, 40),
                Tag = invitation.Token
            };
            btnDecline.Appearance.BackColor = ColorPalette.BorderSlate;
            btnDecline.Appearance.ForeColor = ColorPalette.TextPrimary;
            btnDecline.Appearance.Font = new Font("Segoe UI", 10F);
            btnDecline.Appearance.Options.UseBackColor = true;
            btnDecline.Appearance.Options.UseForeColor = true;
            btnDecline.Appearance.Options.UseFont = true;
            btnDecline.Click += async (s, e) => await DeclineInvitation(invitation.Token);
            card.Controls.Add(btnDecline);

            return card;
        }

        private async Task AcceptInvitation(string token)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                
                var result = await _invitationService.AcceptInvitationAsync(token);
                if (result)
                {
                    FormStyleHelper.ShowSuccess("🎉 You have joined the team successfully!");
                    await LoadInvitationsAsync();
                }
                else
                {
                    FormStyleHelper.ShowError("Failed to accept invitation");
                }
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async Task DeclineInvitation(string token)
        {
            if (!FormStyleHelper.ShowQuestion("Are you sure you want to decline this invitation?"))
                return;

            try
            {
                Cursor = Cursors.WaitCursor;
                
                var result = await _invitationService.DeclineInvitationAsync(token);
                if (result)
                {
                    FormStyleHelper.ShowSuccess("Invitation declined");
                    await LoadInvitationsAsync();
                }
                else
                {
                    FormStyleHelper.ShowError("Failed to decline invitation");
                }
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
