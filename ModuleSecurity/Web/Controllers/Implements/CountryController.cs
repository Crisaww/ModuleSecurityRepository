﻿using Business.Interfaces;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interfaces;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase, ICountryController
    {
        private readonly ICountryBusiness _countryBusiness;

        public CountryController(ICountryBusiness countryBusiness)
        {
            _countryBusiness = countryBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetAll()
        {
            var result = await _countryBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetById(int id)
        {
            var result = await _countryBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> Save([FromBody] CountryDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }

            var result = await _countryBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CountryDto entity)
        {
            if (entity == null || entity.Id == 0)
            {
                return BadRequest();
            }

            await _countryBusiness.Update(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _countryBusiness.Delete(id);
            return NoContent();
        }

        [HttpDelete("logical/{id}")]
        public async Task<IActionResult> LogicalDelete(int id)
        {
                await _countryBusiness.LogicalDelete(id);
                return NoContent(); // Retorna 204 No Content si la operación es exitosa 
        }


        Task<ActionResult<CountryDto>> ICountryController.Save(CountryDto CountryDto)
        {
            throw new NotImplementedException();
        }
    }

}
