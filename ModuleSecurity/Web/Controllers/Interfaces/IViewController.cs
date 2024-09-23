using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IViewController
    {

        public Task<ActionResult<IEnumerable<ViewDto>>> GetAll();
        public Task<ActionResult<ViewDto>> Save([FromBody] ViewDto ViewDto);
        public Task<IActionResult> Update([FromBody] ViewDto ViewDto);
        public Task<IActionResult> Delete(int id);
        public Task<IActionResult> LogicalDelete(int id);
    }
}
