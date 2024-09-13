using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IModuloController
    {
        public Task<ActionResult<IEnumerable<ModuloDto>>> GetAll();
        public Task<ActionResult<ModuloDto>> GetById(int id);
        public Task<ActionResult<ModuloDto>> Save([FromBody] ModuloDto ModuleDto);
        public Task<IActionResult> Update([FromBody] ModuloDto ModuleDto);
        public Task<IActionResult> Delete(int id);
    }
}
