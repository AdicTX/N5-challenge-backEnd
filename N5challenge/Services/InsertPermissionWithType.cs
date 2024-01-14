using N5challenge.Models;
using N5challenge.Models.Repositories;

namespace N5challenge.Services
{
    public class InsertPermissionWithType
    {
        private readonly IUnitOfWork _unitOfWork;
        public InsertPermissionWithType(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(string descripction)
        {
            PermissionType perType = new PermissionType()
            {
                Descripcion = descripction

            };

            await _unitOfWork.PermissionTypeRepository.Insert(perType);
            await _unitOfWork.Save();
        }
    }
}
