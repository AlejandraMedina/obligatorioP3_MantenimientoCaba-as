using Aplicacion;
using Aplicacion.Interfacaces;
using Aplicacion.Interfaces;
using DTOs;
using ExcepcionesPropias;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")] //http://localhost:xxxx/api/tipos
    [ApiController]
    public class TiposController : ControllerBase
    {

        public IAltaTipo CUAltaTipo { get; set; }
   
        public IListadoTipos CUListadoTipos { get; set; }

        public IBuscarTipoPorId CUBuscarTipoPorId{ get; set; }


        public TiposController(IAltaTipo cuAltaTipo, IListadoTipos cuListadoTipo, IBuscarTipoPorId cuBuscarTipoPorId)
        {
            CUAltaTipo = cuAltaTipo;
            CUListadoTipos = cuListadoTipo;
            CUBuscarTipoPorId = cuBuscarTipoPorId;

        }



        // GET: api/<TiposController>
        [HttpGet]
        public IActionResult Get()  //Find all
        {
            IEnumerable<TipoDTO> tipos = CUListadoTipos.ObtenerListado();
            return Ok(tipos);
        }

        // GET api/<TiposController>/5
        [HttpGet("{id}", Name = "FindById")]
        public IActionResult Get(int id)  //  FindBy Id 
        {
            if (id == 0) return BadRequest("El id proporcionado no es válido");

            try
            {
                TipoDTO tipo = CUBuscarTipoPorId.Buscar(id); 
                if (tipo == null) return NotFound($"No existe el tipo con id: {id}");

                return Ok(tipo);
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            
            }

        }


        [HttpGet("nombre/{texto}")]

        public IActionResult BuscarPorNombre(string texto)  //  FindByName
        {
            return Ok();
        }



        // POST api/<TiposController>
        [HttpPost]
        [ActionName (nameof(Post))]
        public IActionResult Post([FromBody] TipoDTO? tipo)   //Add
        {
            if (tipo == null) return BadRequest("No se envió información de tipo");
            try
            {

                CUAltaTipo.Alta(tipo);
            }
            catch (NombreTipoInvalidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error, no se pudo dara el alta de tipo");
                
            }
            return CreatedAtRoute("FindById", new { id = tipo.Id }, tipo);

        }

        // PUT api/<TiposController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)   // Update 
        {
            return Ok();
        }

        // DELETE api/<TiposController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)  // Delete 
        {
            return NoContent();
        }
    }
}
