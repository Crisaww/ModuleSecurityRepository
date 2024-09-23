using Business.Implements;
using Business.Interfaces;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interfaces;

namespace Web.Controllers.Implements
{
    namespace Controller.Implementacion
    {
        [ApiController]
        [Route("[controller]")]
        public class ModuloController : ControllerBase, IModuloController
        {
            private readonly IModuloBusiness _moduleBusiness;

            public ModuloController(IModuloBusiness moduleBusiness)
            {
                _moduleBusiness = moduleBusiness;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<ModuloDto>>> GetAll()
            {
                var result = await _moduleBusiness.GetAll();
                return Ok(result);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<ModuloDto>> GetById(int id)
            {
                var result = await _moduleBusiness.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }

            [HttpPost]
            public async Task<ActionResult<Modulo>> Save([FromBody] ModuloDto entity)
            {
                if (entity == null)
                {
                    return BadRequest("Entity is null");
                }

                var result = await _moduleBusiness.Save(entity);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update([FromBody] ModuloDto entity)
            {
                if (entity == null || entity.Id == 0)
                {
                    return BadRequest();
                }

                await _moduleBusiness.Update(entity);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                await _moduleBusiness.Delete(id);
                return NoContent();
            }

            [HttpDelete("logical/{id}")]
            public async Task<IActionResult> LogicalDelete(int id)
            {
                await _moduleBusiness.LogicalDelete(id);
                return NoContent();
            }

            Task<ActionResult<ModuloDto>> IModuloController.Save(ModuloDto ModuleDto)
            {
                throw new NotImplementedException();
            }
        }
    }

}

