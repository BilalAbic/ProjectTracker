using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
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
                btnCreateTeam.Appearance.BackColor = Color.FromArgb(255, 100, 50);
            };
            btnCreateTeam.MouseLeave += (s, e) => 
            {
                btnCreateTeam.Appearance.BackColor = Color.FromArgb(255, 77, 0);
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
                
                // Load all teams for current user
                _allTeams = (await _teamService.GetUserTeamsAsync()).ToList();
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
                XtraMessageBox.Show(
                    $"Error loading teams: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
            // Main card panel
            var card = new PanelControl
            {
                Width = 340,
                Height = 220,
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple,
                Margin = new Padding(0, 0, 15, 15)
            };
            card.Appearance.BackColor = Color.FromArgb(21, 21, 21);
            card.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            
            // Team icon & name
            var lblName = new LabelControl
            {
                Text = $"🏢 {team.TeamName}",
                Location = new Point(15, 15),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(310, 28)
            };
            lblName.Appearance.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblName.Appearance.ForeColor = Color.White;
            card.Controls.Add(lblName);
            
            // Separator line
            var separator = new PanelControl
            {
                Location = new Point(15, 50),
                Size = new Size(310, 1),
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            };
            separator.Appearance.BackColor = Color.FromArgb(42, 42, 42);
            card.Controls.Add(separator);
            
            // Owner
            var lblOwner = new LabelControl
            {
                Text = $"Owner: {team.OwnerName}",
                Location = new Point(15, 60),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(310, 20)
            };
            lblOwner.Appearance.Font = new Font("Segoe UI", 9);
            lblOwner.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            card.Controls.Add(lblOwner);
            
            // Members count
            var lblMembers = new LabelControl
            {
                Text = $"👥 {team.MemberCount} members",
                Location = new Point(15, 85),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(310, 20)
            };
            lblMembers.Appearance.Font = new Font("Segoe UI", 9);
            lblMembers.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            card.Controls.Add(lblMembers);
            
            // Projects count
            var lblProjects = new LabelControl
            {
                Text = $"📁 {team.ProjectCount} projects",
                Location = new Point(15, 110),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(310, 20)
            };
            lblProjects.Appearance.Font = new Font("Segoe UI", 9);
            lblProjects.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            card.Controls.Add(lblProjects);
            
            // Created date
            var lblCreated = new LabelControl
            {
                Text = $"Created: {team.CreatedAt:dd MMM yyyy}",
                Location = new Point(15, 135),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(310, 20)
            };
            lblCreated.Appearance.Font = new Font("Segoe UI", 9);
            lblCreated.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            card.Controls.Add(lblCreated);
            
            // Settings button
            var btnSettings = new SimpleButton
            {
                Text = "⚙️ Settings",
                Location = new Point(15, 170),
                Size = new Size(145, 32)
            };
            btnSettings.Appearance.BackColor = Color.FromArgb(42, 42, 42);
            btnSettings.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            btnSettings.Click += (s, e) => OpenTeamSettings(team.TeamId);
            card.Controls.Add(btnSettings);
            
            // Switch button
            var btnSwitch = new SimpleButton
            {
                Text = team.TeamId == _currentActiveTeamId ? "✓ Active" : "Switch",
                Location = new Point(170, 170),
                Size = new Size(155, 32)
            };
            
            if (team.TeamId == _currentActiveTeamId)
            {
                btnSwitch.Appearance.BackColor = Color.FromArgb(0, 208, 132); // Green
                btnSwitch.Appearance.ForeColor = Color.White;
                btnSwitch.Enabled = false;
            }
            else
            {
                btnSwitch.Appearance.BackColor = Color.FromArgb(255, 77, 0); // Orange
                btnSwitch.Appearance.ForeColor = Color.White;
                btnSwitch.Click += async (s, e) => await SwitchTeamAsync(team.TeamId);
            }
            
            card.Controls.Add(btnSwitch);
            
            return card;
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
                XtraMessageBox.Show(
                    $"Error opening team creation: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
        private async void LueActiveTeam_EditValueChanged(object sender, EventArgs e)
        {
            if (lueActiveTeam.EditValue != null)
            {
                int teamId = (int)lueActiveTeam.EditValue;
                if (teamId != _currentActiveTeamId)
                {
                    await SwitchTeamAsync(teamId);
                }
            }
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
                XtraMessageBox.Show(
                    $"Error opening team settings: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Switch active team
        /// </summary>
        private async System.Threading.Tasks.Task SwitchTeamAsync(int teamId)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                
                await _teamService.SetActiveTeamAsync(teamId);
                _currentActiveTeamId = teamId;
                
                // Re-render cards to update active state
                RenderTeamCards();
                
                XtraMessageBox.Show(
                    "Team switched successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                
                // TODO: Reload dashboard with new team context
                // ((FrmDashboard)this.ParentForm).ReloadDashboard();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Error switching team: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        
        #endregion
    }
}
