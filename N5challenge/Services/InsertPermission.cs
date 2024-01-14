using N5challenge.Models;
using N5challenge.Models.Repositories;

namespace N5challenge.Services
{
    public class InsertPermission
    {
        private readonly IUnitOfWork _unitOfWork;
        public InsertPermission(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Execute(string name, string lastName, DateOnly date, int typeId)
        {
            
            List<Permission> permissions = new List<Permission>(){
                new Permission()
                {
                    Nombreempleado = name,
                    Apellidoempleado = lastName,
                    Tipopermiso = typeId,
                    Fechapermiso = date
                }
             };

            await _unitOfWork.PermissionRepository.Insert(permissions);
            await _unitOfWork.Save();
        }

    }
}

