using ProjectTracker.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTracker.Core.Interfaces.Repositories
{
    /// <summary>
    /// Repository interface for Task entity with specialized operations
    /// </summary>
    public interface ITaskRepository : IRepository<Core.Entities.Task>
    {
        // Custom methods can be added here if needed in the future
        // For now, GetAllAsync will be overridden in the implementation
        // to include navigation properties
    }
}
