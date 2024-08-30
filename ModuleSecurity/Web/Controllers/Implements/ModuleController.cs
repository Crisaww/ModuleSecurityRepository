using Business.Interfaces;
using Entity.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Web.Controllers.Interfaces;

namespace Web.Controllers.Implements
{
    namespace Controller.Implementacion
    {
        [ApiController]
        [Route("[controller]")]
        public class ModuleController : ControllerBase, IModuleController
        {
            private readonly IModuleBusiness _moduleBusiness;

            public ModuleController(IModuleBusiness moduleBusiness)
            {
                _moduleBusiness = moduleBusiness;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<ModuleDto>>> GetAll()
            {
                var result = await _moduleBusiness.GetAll();
                return Ok(result);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<ModuleDto>> GetById(int id)
            {
                var result = await _moduleBusiness.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }

            [HttpPost]
            public async Task<ActionResult<Module>> Save([FromBody] ModuleDto entity)
            {
                if (entity == null)
                {
                    return BadRequest("Entity is null");
                }

                var result = await _moduleBusiness.Save(entity);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update([FromBody] ModuleDto entity)
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

            Task<ActionResult<ModuleDto>> IModuleController.Save(ModuleDto ModuleDto)
            {
                throw new NotImplementedException();
            }
        }
    }

}

