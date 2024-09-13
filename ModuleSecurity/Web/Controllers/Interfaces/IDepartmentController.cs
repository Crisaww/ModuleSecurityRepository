using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IDepartmentController
    {
        public Task<ActionResult<IEnumerable<DepartmentDto>>> GetAll();
        public Task<ActionResult<DepartmentDto>> GetById(int id);
        public Task<ActionResult<DepartmentDto>> Save([FromBody] DepartmentDto StateDto);
        public Task<IActionResult> Update([FromBody] DepartmentDto StateDto);
        public Task<IActionResult> Delete(int id);
    }
}
