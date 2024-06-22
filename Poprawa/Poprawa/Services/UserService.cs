
using Microsoft.EntityFrameworkCore;
using Poprawa.Data;
using Poprawa.Models;

namespace Poprawa.Services
{
    public class UserService
    {
        private readonly TaskManagementContext _context;

        public UserService(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<bool> UserHasAccessToProjectAsync(int userId, int projectId)
        {
            return await _context.Accesses
                .AnyAsync(a => a.UserId == userId && a.ProjectId == projectId);
        }

        // Dodaj dodatkowe metody według potrzeb
    }
}