using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IUserController
    {
        public Task<ActionResult<IEnumerable<UserDto>>> GetAll();
        public Task<ActionResult<UserDto>> Save([FromBody] UserDto UserDto);
        public Task<IActionResult> Update([FromBody] UserDto UserDto);
        public Task<IActionResult> Delete(int id);
    }
}
