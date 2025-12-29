using Microsoft.EntityFrameworkCore;
using ProjectTracker.Core.Interfaces.Repositories;
using ProjectTracker.Data.Context;
using ProjectTracker.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTracker.Data.Repositories
{
    /// <summary>
    /// Repository for Project entity with navigation property includes
    /// </summary>
    public class ProjectRepository : Repository<Core.Entities.Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets all projects with related CreatedByUser loaded
        /// </summary>
        public override async Task<IEnumerable<Core.Entities.Project>> GetAllAsync()
        {
            return await _dbSet
                .Include(p => p.CreatedByUser)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a project by ID with related entities loaded
        /// </summary>
        public override async Task<Core.Entities.Project> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(p => p.CreatedByUser)
                .Include(p => p.Tasks)
                .Include(p => p.TeamMembers)
                .FirstOrDefaultAsync(p => p.ProjectId == id)
                .ConfigureAwait(false);
        }
    }
}
