using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace N5challenge.Models.Repositories
{
    public interface IPermissionRepository
    {
        Task Insert(List<Permission> permissions);
        Task<Permission?> GetById(int id);

        Task<List<Permission>> GetAll();

        Task<int> GetAllCount();

        void Update(Permission permission);
    }
    public class PermissionRepository : IPermissionRepository
    {
        private readonly N5challengeContext _context;

        public PermissionRepository(N5challengeContext context)
        {
            _context = context;
        }

        public async Task<Permission?> GetById(int id)
        {
            return await _context.Permissions
                 .Include(a => a.TipopermisoNavigation)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(List<Permission> permissions)
            => await _context.Permissions.AddRangeAsync(permissions);

        public async Task<List<Permission>> GetAll()
            => await _context.Permissions
            .Include(a => a.TipopermisoNavigation)
            .ToListAsync();

        public async Task<int> GetAllCount()
        {
            return await _context.Permissions.CountAsync();
        }

        public void Update(Permission permission)
        {
            _context.Permissions.Update(permission);
        }
            
    }

}