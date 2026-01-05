using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
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
    /// Team members content control - Member management and role editing
    /// </summary>
    public partial class TeamMembersContent : UserControl
    {
        #region Fields
        
        private readonly ITeamService _teamService;
        private List<TeamMemberDto>? _allMembers;
        private List<TeamMemberDto>? _filteredMembers;
        
        #endregion
        
        #region Constructor
        
        public TeamMembersContent(ITeamService teamService)
        {
            InitializeComponent();
            _teamService = teamService;
            
            SetupGrid();
            SetupEventHandlers();
            LoadMembersAsync();
        }
        
        public TeamMembersContent()
        {
            InitializeComponent();
        }
        
        #endregion
        
        #region Setup
        
        private void SetupGrid()
        {
            // Custom drawing for initials
            grvMembers.CustomDrawCell += GridView_CustomDrawCell;
            
            // Make role column editable
            grvMembers.OptionsBehavior.Editable = true;
            colRole.OptionsColumn.AllowEdit = true;
            
            // Repository role changed
            repositoryItemComboBox1.EditValueChanged += RoleComboBox_EditValueChanged;
        }
        
        private void SetupEventHandlers()
        {
            // Search filter
            txtSearch.EditValueChanged += (s, e) => ApplyFilter();
            
            // Role filter
            cmbRoleFilter.SelectedIndexChanged += (s, e) => ApplyFilter();
            
            // Clear filters
            btnClear.Click += (s, e) =>
            {
                txtSearch.Text = string.Empty;
                cmbRoleFilter.SelectedIndex = 0;
                ApplyFilter();
            };
        }
        
        #endregion
        
        #region Data Loading
        
        private async void LoadMembersAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                
                var activeTeam = await _teamService.GetActiveTeamAsync();
                if (activeTeam == null)
                {
                    FormStyleHelper.ShowWarning("No active team selected");
                    return;
                }
                
                _allMembers = (await _teamService.GetTeamMembersAsync(activeTeam.TeamId)).ToList();
                _filteredMembers = _allMembers.ToList();
                
                grdMembers.DataSource = _filteredMembers;
                grvMembers.RefreshData();
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error loading members: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        
        #endregion
        
        #region Filtering
        
        private void ApplyFilter()
        {
            if (_allMembers == null)
                return;
            
            string searchText = txtSearch.Text.ToLower();
            string roleFilter = cmbRoleFilter.Text;
            
            _filteredMembers = _allMembers.Where(m =>
            {
                bool matchesSearch = string.IsNullOrWhiteSpace(searchText) ||
                    m.UserName.ToLower().Contains(searchText) ||
                    m.Email.ToLower().Contains(searchText);
                
                bool matchesRole = roleFilter == "All Roles" || string.IsNullOrEmpty(roleFilter) ||
                    m.RoleName == roleFilter;
                
                return matchesSearch && matchesRole;
            }).ToList();
            
            grdMembers.DataSource = _filteredMembers;
            grvMembers.RefreshData();
        }
        
        #endregion
        
        #region Role Editing
        
        private async void RoleComboBox_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var member = grvMembers.GetFocusedRow() as TeamMemberDto;
                if (member == null)
                    return;
                
                // Get new role from editor
                var editor = sender as ComboBoxEdit;
                if (editor == null || editor.EditValue == null)
                    return;
                
                var newRoleText = editor.EditValue.ToString();
                if (string.IsNullOrEmpty(newRoleText))
                    return;
                
                // Convert display name to enum
                var roleEnum = newRoleText.Replace(" ", "") switch
                {
                    "Owner" => Core.Enums.TeamRole.Owner,
                    "Admin" => Core.Enums.TeamRole.Admin,
                    "ProjectManager" => Core.Enums.TeamRole.ProjectManager,
                    "Developer" => Core.Enums.TeamRole.Developer,
                    "Observer" => Core.Enums.TeamRole.Observer,
                    _ => Core.Enums.TeamRole.Developer
                };
                
                await _teamService.UpdateMemberRoleAsync(member.TeamMemberId, roleEnum);
                
                member.RoleName = newRoleText;
                grvMembers.RefreshData();
                
                FormStyleHelper.ShowSuccess($"Role updated to {newRoleText}!");
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error updating role: {ex.Message}");
                grvMembers.CancelUpdateCurrentRow();
            }
        }
        
        #endregion
        
        #region Custom Drawing
        
        private void GridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Initials")
            {
                var member = grvMembers.GetRow(e.RowHandle) as TeamMemberDto;
                if (member != null)
                {
                    e.Handled = true;
                    
                    // Draw background first
                    using (var bgBrush = new SolidBrush(e.Appearance.BackColor))
                    {
                        e.Graphics.FillRectangle(bgBrush, e.Bounds);
                    }
                    
                    // Draw colored circle - küçük ve ortalanmış
                    var roleColor = GetRoleColor(member.RoleName);
                    int circleSize = 26;
                    int circleX = e.Bounds.X + (e.Bounds.Width - circleSize) / 2;
                    int circleY = e.Bounds.Y + (e.Bounds.Height - circleSize) / 2;
                    
                    // Anti-aliasing için
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    
                    using (var brush = new SolidBrush(roleColor))
                    {
                        e.Graphics.FillEllipse(brush, circleX, circleY, circleSize, circleSize);
                    }
                    
                    // Draw initials
                    var initials = GetInitials(member.UserName);
                    using (var font = new Font("Segoe UI", 9, FontStyle.Bold))
                    using (var textBrush = new SolidBrush(Color.White))
                    {
                        var textSize = e.Graphics.MeasureString(initials, font);
                        var x = circleX + (circleSize - textSize.Width) / 2;
                        var y = circleY + (circleSize - textSize.Height) / 2;
                        e.Graphics.DrawString(initials, font, textBrush, x, y);
                    }
                }
            }
        }
        
        private Color GetRoleColor(string roleName)
        {
            return roleName switch
            {
                "Owner" => ColorPalette.AccentRoyalBlue,
                "Admin" => ColorPalette.CategoryPurple,
                "Project Manager" => ColorPalette.WarningAmber,
                "Developer" => ColorPalette.SuccessGreen,
                "Observer" => ColorPalette.TextSecondary,
                _ => ColorPalette.TextSecondary
            };
        }
        
        private string GetInitials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return "?";
            
            var parts = fullName.Trim().Split(' ');
            if (parts.Length >= 2)
                return $"{parts[0][0]}{parts[1][0]}".ToUpper();
            
            return fullName.Length >= 2 
                ? fullName.Substring(0, 2).ToUpper() 
                : fullName.ToUpper();
        }
        
        #endregion
    }
}
