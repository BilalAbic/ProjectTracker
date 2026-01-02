using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
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
    /// Teams content control - Team list and switcher
    /// </summary>
    public partial class TeamsContent : UserControl
    {
        #region Fields
        
        private readonly ITeamService _teamService;
        private List<TeamDto> _allTeams;
        private List<TeamDto> _filteredTeams;
        private int? _currentActiveTeamId;
        
        #endregion
        
        #region Constructor
        
        /// <summary>
        /// Initializes a new instance of the TeamsContent class
        /// </summary>
        /// <param name="teamService">Team service instance</param>
        public TeamsContent(ITeamService teamService)
        {
            InitializeComponent();
            _teamService = teamService;
            
            // Setup
            SetupEventHandlers();
            LoadTeamsAsync();
        }
        
        /// <summary>
        /// Parameterless constructor for Designer
        /// </summary>
        public TeamsContent()
        {
            InitializeComponent();
        }
        
        #endregion
        
        #region Setup Methods
        
        /// <summary>
        /// Setup all event handlers
        /// </summary>
        private void SetupEventHandlers()
        {
            // Developer için Create Team butonunu gizle
            if (SessionManager.IsDeveloper)
            {
                btnCreateTeam.Visible = false;
            }

            // Create Team button
            btnCreateTeam.Click += BtnCreateTeam_Click;
            
            // Refresh button
            btnRefresh.Click += BtnRefresh_Click;
            
            // Search
            txtSearch.EditValueChanged += TxtSearch_EditValueChanged;
            
            // Active team selector
            lueActiveTeam.EditValueChanged += LueActiveTeam_EditValueChanged;
            
            // Hover effects
            SetupHoverEffects();
        }
        
        /// <summary>
        /// Setup button hover effects
        /// </summary>
        private void SetupHoverEffects()
        {
            // Create Team button
            btnCreateTeam.MouseEnter += (s, e) => 
            {
                btnCreateTeam.Appearance.BackColor = ColorPalette.AccentSkyBlue;
            };
            btnCreateTeam.MouseLeave += (s, e) =>
            {
                btnCreateTeam.Appearance.BackColor = ColorPalette.AccentRoyalBlue;
            };
        }
        
        #endregion
        
        #region Data Loading
        
        /// <summary>
        /// Load teams from database
        /// </summary>
        private async void LoadTeamsAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                
                // ROL BAZLI FİLTRELEME
                if (SessionManager.IsAdmin)
                {
                    // Admin: Tüm takımları göster
                    _allTeams = (await _teamService.GetAllTeamsAsync()).ToList();
                }
                else
                {
                    // ProjectManager/Developer: Sadece üye oldukları takımlar
                    _allTeams = (await _teamService.GetUserTeamsAsync()).ToList();
                }
                
                _filteredTeams = _allTeams.ToList();
                
                // Load active team
                var activeTeam = await _teamService.GetActiveTeamAsync();
                _currentActiveTeamId = activeTeam?.TeamId;
                
                // Populate active team selector
                lueActiveTeam.Properties.DataSource = _allTeams;
                lueActiveTeam.EditValue = _currentActiveTeamId;
                
                // Render team cards
                RenderTeamCards();
                
                // Update count
                UpdateRecordCount();
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error loading teams: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        
        /// <summary>
        /// Update record count label
        /// </summary>
        private void UpdateRecordCount()
        {
            lblRecordCount.Text = $"Showing {_filteredTeams.Count} of {_allTeams.Count} teams";
        }
        
        #endregion
        
        #region Team Card Rendering
        
        /// <summary>
        /// Render team cards in flow layout
        /// </summary>
        private void RenderTeamCards()
        {
            flowTeamCards.Controls.Clear();
            
            foreach (var team in _filteredTeams)
            {
                var card = CreateTeamCard(team);
                flowTeamCards.Controls.Add(card);
            }
        }
        
        /// <summary>
        /// Create a team card panel
        /// </summary>
        private PanelControl CreateTeamCard(TeamDto team)
        {
            // Card dimensions - 4 kart yan yana (container ~980px, 4 kart = 235px each)
            const int cardWidth = 235;
            const int cardHeight = 180;
            
            // Main card panel - açık arka plan
            var card = new PanelControl
            {
                Width = cardWidth,
                Height = cardHeight,
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple,
                Margin = new Padding(5, 5, 5, 5)
            };
            card.Appearance.BackColor = Color.FromArgb(240, 243, 247); // Açık gri-beyaz
            card.Appearance.BorderColor = Color.FromArgb(200, 210, 220);
            card.Appearance.Options.UseBackColor = true;
            card.Appearance.Options.UseBorderColor = true;
            
            // Team icon & name
            var lblName = new LabelControl
            {
                Text = $"🏢 {team.TeamName}",
                Location = new Point(12, 10),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(cardWidth - 24, 22)
            };
            lblName.Appearance.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblName.Appearance.ForeColor = Color.FromArgb(30, 40, 50); // Koyu siyah
            lblName.Appearance.Options.UseFont = true;
            lblName.Appearance.Options.UseForeColor = true;
            card.Controls.Add(lblName);
            
            // Separator line
            var separator = new PanelControl
            {
                Location = new Point(12, 35),
                Size = new Size(cardWidth - 24, 1),
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            };
            separator.Appearance.BackColor = Color.FromArgb(180, 190, 200);
            separator.Appearance.Options.UseBackColor = true;
            card.Controls.Add(separator);
            
            // Owner
            var lblOwner = new LabelControl
            {
                Text = $"Owner: {team.OwnerName}",
                Location = new Point(12, 42),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(cardWidth - 24, 18)
            };
            lblOwner.Appearance.Font = new Font("Segoe UI", 8.5F);
            lblOwner.Appearance.ForeColor = Color.FromArgb(80, 90, 100); // Koyu gri
            lblOwner.Appearance.Options.UseFont = true;
            lblOwner.Appearance.Options.UseForeColor = true;
            card.Controls.Add(lblOwner);
            
            // Members count
            var lblMembers = new LabelControl
            {
                Text = $"👥 {team.MemberCount} members",
                Location = new Point(12, 62),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(cardWidth - 24, 18)
            };
            lblMembers.Appearance.Font = new Font("Segoe UI", 8.5F);
            lblMembers.Appearance.ForeColor = Color.FromArgb(50, 60, 70); // Siyah
            lblMembers.Appearance.Options.UseFont = true;
            lblMembers.Appearance.Options.UseForeColor = true;
            card.Controls.Add(lblMembers);
            
            // Projects count
            var lblProjects = new LabelControl
            {
                Text = $"📁 {team.ProjectCount} projects",
                Location = new Point(12, 82),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(cardWidth - 24, 18)
            };
            lblProjects.Appearance.Font = new Font("Segoe UI", 8.5F);
            lblProjects.Appearance.ForeColor = Color.FromArgb(50, 60, 70); // Siyah
            lblProjects.Appearance.Options.UseFont = true;
            lblProjects.Appearance.Options.UseForeColor = true;
            card.Controls.Add(lblProjects);
            
            // Created date
            var lblCreated = new LabelControl
            {
                Text = $"Created: {team.CreatedAt:dd MMM yyyy}",
                Location = new Point(12, 102),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(cardWidth - 24, 18)
            };
            lblCreated.Appearance.Font = new Font("Segoe UI", 8F);
            lblCreated.Appearance.ForeColor = Color.FromArgb(100, 110, 120); // Gri
            lblCreated.Appearance.Options.UseFont = true;
            lblCreated.Appearance.Options.UseForeColor = true;
            card.Controls.Add(lblCreated);
            
            // Button width calculation - 2 buton yan yana
            int buttonWidth = (cardWidth - 34) / 2; // 34 = 12 + 10 + 12 (margins)
            int buttonY = cardHeight - 40;
            
            // Settings button - Developer için gizle
            var btnSettings = new SimpleButton
            {
                Text = "⚙️ Settings",
                Location = new Point(12, buttonY),
                Size = new Size(buttonWidth, 28),
                Visible = !SessionManager.IsDeveloper
            };
            btnSettings.Appearance.BackColor = Color.FromArgb(100, 116, 139); // Slate
            btnSettings.Appearance.ForeColor = Color.White;
            btnSettings.Appearance.Font = new Font("Segoe UI", 8F);
            btnSettings.Appearance.Options.UseBackColor = true;
            btnSettings.Appearance.Options.UseForeColor = true;
            btnSettings.Appearance.Options.UseFont = true;
            btnSettings.Click += (s, e) => OpenTeamSettings(team.TeamId);
            card.Controls.Add(btnSettings);
            
            // Invite button
            bool canInvite = SessionManager.IsAdmin || team.OwnerId == SessionManager.CurrentUserId;
            var btnInvite = new SimpleButton
            {
                Text = "📧 Invite",
                Location = new Point(12 + buttonWidth + 10, buttonY),
                Size = new Size(buttonWidth, 28),
                Visible = canInvite
            };
            btnInvite.Appearance.BackColor = ColorPalette.AccentRoyalBlue;
            btnInvite.Appearance.ForeColor = Color.White;
            btnInvite.Appearance.Font = new Font("Segoe UI", 8F);
            btnInvite.Appearance.Options.UseBackColor = true;
            btnInvite.Appearance.Options.UseForeColor = true;
            btnInvite.Appearance.Options.UseFont = true;
            btnInvite.Click += (s, e) => OpenInviteDialog(team.TeamId, team.TeamName);
            card.Controls.Add(btnInvite);
            
            return card;
        }
        
        /// <summary>
        /// Open invite dialog for team
        /// </summary>
        private void OpenInviteDialog(int teamId, string teamName)
        {
            try
            {
                var invitationsContent = Program.ServiceProvider.GetRequiredService<InvitationsContent>();
                invitationsContent.SetTeamContext(teamId, teamName);
                ((FrmDashboard)this.ParentForm).LoadContent(invitationsContent);
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error opening invitations: {ex.Message}");
            }
        }
        
        #endregion
        
        #region Filtering
        
        /// <summary>
        /// Apply search filter
        /// </summary>
        private void ApplyFilter()
        {
            string searchText = txtSearch.Text.ToLower();
            
            if (string.IsNullOrWhiteSpace(searchText))
            {
                _filteredTeams = _allTeams.ToList();
            }
            else
            {
                _filteredTeams = _allTeams.Where(t =>
                    t.TeamName.ToLower().Contains(searchText) ||
                    t.OwnerName.ToLower().Contains(searchText)
                ).ToList();
            }
            
            RenderTeamCards();
            UpdateRecordCount();
        }
        
        #endregion
        
        #region Event Handlers
        
        /// <summary>
        /// Create Team button clicked
        /// </summary>
        private void BtnCreateTeam_Click(object sender, EventArgs e)
        {
            try
            {
                var teamDetailControl = Program.ServiceProvider.GetRequiredService<TeamDetailControl>();
                ((FrmDashboard)this.ParentForm).LoadContent(teamDetailControl);
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error opening team creation: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Refresh button clicked
        /// </summary>
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadTeamsAsync();
        }
        
        /// <summary>
        /// Search text changed
        /// </summary>
        private void TxtSearch_EditValueChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        
        /// <summary>
        /// Active team changed from dropdown
        /// </summary>
        private void LueActiveTeam_EditValueChanged(object sender, EventArgs e)
        {
            // Active team seçimi artık kullanılmıyor
        }
        
        /// <summary>
        /// Open team settings
        /// </summary>
        private void OpenTeamSettings(int teamId)
        {
            try
            {
                var teamDetailControl = Program.ServiceProvider.GetRequiredService<TeamDetailControl>();
                teamDetailControl.LoadTeamForEdit(teamId);
                ((FrmDashboard)this.ParentForm).LoadContent(teamDetailControl);
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error opening team settings: {ex.Message}");
            }
        }
        
        #endregion
    }
}
