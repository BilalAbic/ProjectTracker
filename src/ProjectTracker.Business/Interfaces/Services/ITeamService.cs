using ProjectTracker.Business.DTOs;
using ProjectTracker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTracker.Business.Interfaces
{
    /// <summary>
    /// Team service interface - handles team business logic
    /// </summary>
    public interface ITeamService
    {
        /// <summary>
        /// Get all teams in the system (Admin only)
        /// </summary>
        Task<IEnumerable<TeamDto>> GetAllTeamsAsync();

        /// <summary>
        /// Get all teams for the current user
        /// </summary>
        Task<IEnumerable<TeamDto>> GetUserTeamsAsync();

        /// <summary>
        /// Get the active team for the current user
        /// </summary>
        Task<TeamDto?> GetActiveTeamAsync();

        /// <summary>
        /// Get team by ID
        /// </summary>
        Task<TeamDto?> GetTeamByIdAsync(int teamId);

        /// <summary>
        /// Create new team
        /// </summary>
        Task<TeamDto> CreateTeamAsync(CreateTeamDto createDto);

        /// <summary>
        /// Update team
        /// </summary>
        Task<TeamDto> UpdateTeamAsync(UpdateTeamDto updateDto);

        /// <summary>
        /// Delete team
        /// </summary>
        Task<bool> DeleteTeamAsync(int teamId);

        /// <summary>
        /// Set active team for the current user
        /// </summary>
        Task SetActiveTeamAsync(int teamId);

        /// <summary>
        /// Get all members of a team
        /// </summary>
        Task<IEnumerable<TeamMemberDto>> GetTeamMembersAsync(int teamId);

        /// <summary>
        /// Update member role
        /// </summary>
        Task<bool> UpdateMemberRoleAsync(int teamMemberId, TeamRole newRole);

        /// <summary>
        /// Remove member from team
        /// </summary>
        Task<bool> RemoveMemberAsync(int teamMemberId);
    }
}
