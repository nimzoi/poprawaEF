using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Poprawa.Data;
using Poprawa.Models;

namespace Poprawa.Services
{
    public class ProjectService
    {
        private readonly TaskManagementContext _context;

        public ProjectService(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            return await _context.Projects
                .FirstOrDefaultAsync(p => p.ProjectId == projectId);
        }


    }
}