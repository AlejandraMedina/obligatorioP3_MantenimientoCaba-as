using Aplicacion;
using Aplicacion.Interfacaces;
using Aplicacion.Interfaces;
using Datos.Repositorios;
using Dominio.EntidadesNegocio;
using DTOs;
using ExcepcionesPropias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")] //http://localhost:xxxx/api/tipos
    [ApiController]
    public class TiposController : ControllerBase
    {

        public IAltaTipo AltaTipo { get; set; }

        public IListadoTipos ListadoTipos { get; set; }

        public IBuscarTipoPorId BuscarTipoPorId { get; set; }

        public IModificarTipo ModificarTipo { get; set; }

        public IEliminarTipo EliminarTipo { get; set; }

        public IBuscarPorNombre BuscarPorNombre { get; set; }


        public TiposController(IAltaTipo cuAltaTipo, IListadoTipos cuListadoTipo, IBuscarTipoPorId cuBuscarTipoPorId, IModificarTipo cuModificarTipo, IEliminarTipo cuEliminarTipo, IBuscarPorNombre cuBuscarPorNombre)
        {
            AltaTipo = cuAltaTipo;
            ListadoTipos = cuListadoTipo;
            BuscarTipoPorId = cuBuscarTipoPorId;
            ModificarTipo = cuModificarTipo;
            EliminarTipo = cuEliminarTipo;
            BuscarPorNombre = cuBuscarPorNombre;
        }



        // GET: api/<TiposController>
        [HttpGet]
        [Authorize]
        public IActionResult Get()  //Find all
        {
            IEnumerable<TipoDTO> tipos = ListadoTipos.ObtenerListado();
            return Ok(tipos);
        }


        // GET api/<TiposController>/5
        [HttpGet("{id}", Name = "FindById")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)  //  FindBy Id 
        {
            if (id <= 0) return BadRequest("El id proporcionado no es válido");

            try
            {
                TipoDTO tipo = BuscarTipoPorId.Buscar(id);
                if (tipo == null) return NotFound($"No existe el tipo con id: {id}");

                return Ok(tipo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado");

            }

        }

        /// <summary>
        /// Permite buscar temas que contengan el texto iniciado 
        /// </summary>
        /// <param name="texto">El texto ingresado en el campo input de tipos buscados</param>
        /// <returns>Los tipos que incluyen en su nombre el texto pasado por parámetro </returns>

        [HttpGet("nombre/{texto}")]
        [Authorize]

        //public IActionResult BuscarPorNombre(string texto)  //  FindByName
        //{
        //    if (!string.IsNullOrEmpty(texto))
        //    {
        //        return BadRequest("No se ingresó un nombre para la búsqueda");
        //    }

        //    try
        //    {
        //         TipoDTO tipo = BuscarPorNombre.Buscar(texto);
        //        return Ok(tipo);
        //       // return Ok();   // VER QUE ANDE LO DE ARRIBAAAA!
        //    }
        //    catch
        //    {
        //        return StatusCode(500, "Ocurrió un error");
        //    }


        //}




        // POST api/<TiposController>
        [HttpPost]
        [ActionName(nameof(Post))]
        [Authorize]
        public IActionResult Post([FromBody] TipoDTO? tipo)   //Add
        {
            if (tipo == null) return BadRequest("No se envió información de tipo");
            try
            {

                AltaTipo.Alta(tipo);
            }
            catch (NombreTipoInvalidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error, no se pudo dara el alta de tipo");

            }
            return CreatedAtRoute("FindById", new { id = tipo.Id }, tipo);

        }

        // PUT api/<TiposController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] TipoDTO? tipo)   // Update 
        {
            if (id <= 0 || tipo == null || tipo.Id != id) return BadRequest("Los datos proporcionados no son válidos");
            try
            {
                ModificarTipo.Modificar(tipo);
            }

            catch (NombreTipoInvalidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error");
            }
            return Ok(tipo);
        }

        // DELETE api/<TiposController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)  // Delete 
        {
            if (id <= 0) return BadRequest("El id proporcionado no es válido");
            try
            {
                EliminarTipo.Remove(id);
            }
            catch (ErrorTipoException ex)
            {
                return NotFound($"El tipo con id  {id} NotFound se puede borrar porque no existe");
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error");
            }
            return NoContent();
        }
    }
}
