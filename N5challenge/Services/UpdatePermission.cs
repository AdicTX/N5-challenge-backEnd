using N5challenge.Models;

namespace N5challenge.Services
{
    public class UpdatePermission
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePermission(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(int id, string name, string lastName, DateOnly date, int typeId)
        {
            Permission? permission = await _unitOfWork.PermissionRepository.GetById(id);
            if (permission != null) {
                permission.Nombreempleado = name;
                permission.Apellidoempleado = lastName;
                permission.Fechapermiso = date;
                permission.Tipopermiso = typeId;
                _unitOfWork.PermissionRepository.Update(permission);
                await _unitOfWork.Save();
            }
        }
    }
}
