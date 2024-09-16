using Business.Interfaces;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interfaces;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase, IDepartmentController
    {
        private readonly IDepartmentBusiness _departmentBusiness;

        public DepartmentController(IDepartmentBusiness stateBusiness)
        {
            _departmentBusiness = stateBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAll()
        {
            var result = await _departmentBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetById(int id)
        {
            var result = await _departmentBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> Save([FromBody] DepartmentDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }

            var result = await _departmentBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] DepartmentDto entity)
        {
            if (entity == null || entity.Id == 0)
            {
                return BadRequest();
            }

            await _departmentBusiness.Update(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentBusiness.Delete(id);
            return NoContent();
        }

        Task<ActionResult<DepartmentDto>> IDepartmentController.Save(DepartmentDto StateDto)
        {
            throw new NotImplementedException();
        }
    }

}
