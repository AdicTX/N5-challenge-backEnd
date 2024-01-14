using N5challenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using N5challenge.Models.Repositories;
using N5challenge.Services;
using N5challenge.Controllers;

namespace challenge.Controllers
{
    [Route("api/permissionType")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IPermissionTypeRepository _permissionTypeRepository;
        private readonly InsertPermissionWithType _insertPermissionWithType;
        private readonly IUnitOfWork _unitOfWork;

        public PermissionTypeController(IPermissionTypeRepository permissionTypeRepository, InsertPermissionWithType insertPermissionWithType, IUnitOfWork unitOfWork)
        {
            _permissionTypeRepository = permissionTypeRepository;
            _insertPermissionWithType = insertPermissionWithType;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<List<PermissionType>> GetAll()
           => await _unitOfWork.PermissionTypeRepository.GetAll();

        [HttpPost]
        public async Task Create([FromBody] PermissionTypeModal permissionTypeModal)
           => await _insertPermissionWithType.Execute(permissionTypeModal.Descripcion);
    }
}
