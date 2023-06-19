using Aplicacion.Clases;
using Aplicacion.Interfaces;
using Dominio.EntidadesNegocio;
using DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientosController : ControllerBase
    {
        public IAltaMantenimiento AltaMantenimiento { get; set; }

        public IListadoMantenimientos ListadoMantenimientos { get; set; }

        public IBuscarMantenimientoPorId BuscarMantenimientoPorId { get; set; }
        public MantenimientosController (IAltaMantenimiento altaMantenimiento, IListadoMantenimientos listadoMantenimientos, IBuscarMantenimientoPorId buscarMantPorId)
        
        {
            altaMantenimiento = AltaMantenimiento;
            listadoMantenimientos = ListadoMantenimientos;
            buscarMantPorId = BuscarMantenimientoPorId;

        }
        // GET: api/<MantenimientosController>
        [HttpGet]
        public IActionResult Get() // findall
        {
            IEnumerable<MantenimientoDTO> mantenimientos = ListadoMantenimientos.ObtenerListado();
            return Ok(mantenimientos);
        }

        // GET api/<MantenimientosController>/5
        [HttpGet("{id}", Name = "Getmant")]
        public IActionResult Get(int? id) //findById
        {
            if (id == null) return BadRequest("No se envió información del mantenimiento");
            try
            {
                MantenimientoDTO mantDto = BuscarMantenimientoPorId.BuscarMant(id.Value);
                if (mantDto == null) return NotFound("No existe el mantenimiento");
                return Ok(mantDto);
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }
            
            
            
        }

        // POST api/<MantenimientosController>
        [HttpPost]
        public IActionResult Post([FromBody] MantenimientoDTO? mantenimiento) //Add
        {
            if (mantenimiento == null) return BadRequest("No se envió información del mantenimiento");

            try
            {
                AltaMantenimiento.Alta(mantenimiento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error, no se pudo realizar el alta");
            }

            return CreatedAtRoute("Getmant", new { id= mantenimiento.Id}, mantenimiento);
        }

        // PUT api/<MantenimientosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value) //Update
        {
            return Ok();
        }

        // DELETE api/<MantenimientosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) //delete
        {
            return NoContent();
        }
    }
}
