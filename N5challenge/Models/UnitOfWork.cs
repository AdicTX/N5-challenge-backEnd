using N5challenge.Models.Repositories;

namespace N5challenge.Models
{
    public interface IUnitOfWork : IDisposable
    {
        public IPermissionTypeRepository PermissionTypeRepository { get; }
        public IPermissionRepository PermissionRepository { get; }
        Task<int> Save();
    }
    public class unitOfWork : IUnitOfWork
    {
        public IPermissionTypeRepository PermissionTypeRepository { get; }
        public IPermissionRepository PermissionRepository { get; }

        private readonly N5challengeContext _context;

        public unitOfWork(N5challengeContext context, IPermissionRepository permissionRepository, IPermissionTypeRepository permissionTypeRepository)
        {
            _context = context;
            PermissionTypeRepository = permissionTypeRepository;
            PermissionRepository = permissionRepository;
        }

        public async Task<int> Save()
        {
            return await  _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
