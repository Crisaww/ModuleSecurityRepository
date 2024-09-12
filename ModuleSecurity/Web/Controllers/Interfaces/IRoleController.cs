using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IRoleController
    {
        public Task<ActionResult<IEnumerable<RoleDto>>> GetAll();
        public Task<ActionResult<RoleDto>> GetById(int id);
        public Task<ActionResult<RoleDto>> Save([FromBody] RoleDto RoleDto);
        public Task<IActionResult> Update([FromBody] RoleDto RoleDto);
        public Task<IActionResult> Delete(int id);
    }
}
