using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using N5challenge.Models;
using N5challenge.Models.Repositories;
using N5challenge.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace N5challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly UpdatePermission _updatePermission;
        private readonly InsertPermission _insertPermission;
        private readonly IUnitOfWork _unitOfWork;

        public PermissionController(IUnitOfWork unitOfWork, InsertPermission insertPermission, UpdatePermission updatePermission)
        {
            _unitOfWork = unitOfWork;
            _insertPermission = insertPermission;
            _updatePermission = updatePermission;
        }

        //[HttpGet]
        //public async Task<List<PermissionResult>> GetAll()
        //    => await _unitOfWork.PermissionRepository.GetAll();


        [HttpGet]
        public async Task<PermissionResult> GetAll()
        {
            var result = new PermissionResult();

            result.Permissions = await _unitOfWork.PermissionRepository.GetAll();
            result.TotalCount = await _unitOfWork.PermissionRepository.GetAllCount();

            return result;
        }




        [HttpGet("{id}")]
        public async Task<Permission?> GetById(int id)
           => await _unitOfWork.PermissionRepository.GetById(id);

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] UpdateModel insertPer) { 
             try
            {
                DateOnly date = DateOnly.Parse(insertPer.Date);
                await _insertPermission.Execute(insertPer.Name, insertPer.LastName, date, insertPer.TypeId);
                return Ok("Update successful");
              }
            catch (FormatException ex)
            {
                return BadRequest($"Invalid date format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Update failed: {ex.ToString()}");

            return BadRequest($"Update failed: An error occurred while saving the entity changes. See the logs for details.");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateModel updateDto)
        {
            try
            {
                DateOnly date = DateOnly.Parse(updateDto.Date);

                await _updatePermission.Execute(id, updateDto.Name, updateDto.LastName, date, updateDto.TypeId);
                return Ok("Update successful");
            }
            catch (FormatException ex)
            {
                return BadRequest($"Invalid date format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Update failed: {ex.ToString()}");

                return BadRequest($"Update failed: An error occurred while saving the entity changes. See the logs for details.");
            }
        }
    }
}
