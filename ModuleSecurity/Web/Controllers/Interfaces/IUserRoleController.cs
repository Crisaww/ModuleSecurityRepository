using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IUserRoleController
    {
        public Task<ActionResult<IEnumerable<UserRoleDto>>> GetAll();
        public Task<ActionResult<UserRoleDto>> Save([FromBody] UserRoleDto UserRoleDto);
        public Task<IActionResult> Update([FromBody] UserRoleDto UserRoleDto);
        public Task<IActionResult> Delete(int id);
        public Task<IActionResult> LogicalDelete(int id);
    }
}
