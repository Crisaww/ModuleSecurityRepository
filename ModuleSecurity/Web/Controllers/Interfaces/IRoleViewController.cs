using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IRoleViewController
    {
        public Task<ActionResult<IEnumerable<RoleViewDto>>> GetAll();
        public Task<ActionResult<RoleViewDto>> Save([FromBody] RoleViewDto RoleViewDto);
        public Task<IActionResult> Update([FromBody] RoleViewDto RoleViewDto);
        public Task<IActionResult> Delete(int id);
        public Task<IActionResult> LogicalDelete(int id);
    }
}
