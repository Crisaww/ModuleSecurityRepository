using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IStateController
    {
        public Task<ActionResult<IEnumerable<StateDto>>> GetAll();
        public Task<ActionResult<StateDto>> GetById(int id);
        public Task<ActionResult<StateDto>> Save([FromBody] StateDto StateDto);
        public Task<IActionResult> Update([FromBody] StateDto StateDto);
        public Task<IActionResult> Delete(int id);
    }
}
