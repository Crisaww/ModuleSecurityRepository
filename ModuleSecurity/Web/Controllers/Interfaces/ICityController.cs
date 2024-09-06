using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface ICityController
    {
        public Task<ActionResult<IEnumerable<CityDto>>> GetAll();
        public Task<ActionResult<CityDto>> Save([FromBody] CityDto CityDto);
        public Task<IActionResult> Update([FromBody] CityDto CityDto);
        public Task<IActionResult> Delete(int id);
    }
}
