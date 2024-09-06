using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface ICountryController
    {

        public Task<ActionResult<IEnumerable<CountryDto>>> GetAll();
        public Task<ActionResult<CountryDto>> Save([FromBody] CountryDto CountryDto);
        public Task<IActionResult> Update([FromBody] CountryDto CountryDto);
        public Task<IActionResult> Delete(int id);
    }
}
