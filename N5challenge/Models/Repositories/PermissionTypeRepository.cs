using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace N5challenge.Models.Repositories
{
    public interface IPermissionTypeRepository
    {
        Task<PermissionType> Insert(PermissionType permissionType);
        Task<PermissionType?> GetById(int id);

        Task<List<PermissionType>> GetAll();
    }
    public class PermissionTypeRepository: IPermissionTypeRepository
    {
        private readonly N5challengeContext _context;

        public PermissionTypeRepository(N5challengeContext context)
        {
            _context = context;
        }

        public async Task<PermissionType?> GetById(int id)
        {
           return await _context.PermissionTypes
                .Include(a => a.Permissions)
                .FirstOrDefaultAsync(x =>  x.Id == id);
        }

        public async Task<List<PermissionType>> GetAll()
            => await _context.PermissionTypes.ToListAsync();

        public async Task<PermissionType> Insert(PermissionType permissionType)
        {
            EntityEntry<PermissionType> insertedPermission = await _context.PermissionTypes.AddAsync(permissionType);
            return insertedPermission.Entity;
        }
    }
}
