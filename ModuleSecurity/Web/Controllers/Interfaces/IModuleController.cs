using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IModuleController
    {
        public Task<ActionResult<IEnumerable<ModuleDto>>> GetAll();
        public Task<ActionResult<ModuleDto>> Save([FromBody] ModuleDto ModuleDto);
        public Task<IActionResult> Update([FromBody] ModuleDto ModuleDto);
        public Task<IActionResult> Delete(int id);
    }
}
