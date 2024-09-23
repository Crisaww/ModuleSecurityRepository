using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IPersonController
    {

        public Task<ActionResult<IEnumerable<PersonDto>>> GetAll();
        public Task<ActionResult<PersonDto>> GetById(int id);
        public Task<ActionResult<PersonDto>> Save([FromBody] PersonDto PersonDto);
        public Task<IActionResult> Update([FromBody] PersonDto PersonDto);
        public Task<IActionResult> Delete(int id);
        public Task<IActionResult> LogicalDelete(int id);
    }
}
