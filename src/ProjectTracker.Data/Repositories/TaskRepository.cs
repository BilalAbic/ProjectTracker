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
    /// Repository for Task entity with navigation property includes
    /// </summary>
    public class TaskRepository : Repository<Core.Entities.Task>, ITaskRepository
    {
        public TaskRepository(AppDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets all tasks with related Project and AssignedToUser loaded
        /// </summary>
        public override async Task<IEnumerable<Core.Entities.Task>> GetAllAsync()
        {
            return await _context.Set<Core.Entities.Task>()
                .Include(t => t.Project)
                .Include(t => t.AssignedToUser)
                .AsSplitQuery()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a task by ID with related entities loaded
        /// </summary>
        public override async Task<Core.Entities.Task> GetByIdAsync(int id)
        {
            return await _context.Set<Core.Entities.Task>()
                .Include(t => t.Project)
                .Include(t => t.AssignedToUser)
                .FirstOrDefaultAsync(t => t.TaskId == id)
                .ConfigureAwait(false);
        }
    }
}
