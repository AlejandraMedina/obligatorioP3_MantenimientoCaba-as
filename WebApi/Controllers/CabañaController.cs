using Aplicacion.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabañaController : ControllerBase
    {

        public IListadoCabañas ListadoCabañas { get; set; }
        public IAltaCabaña AltaCabaña { get; set; }

        public IBuscarCabaña BuscarCabaña { get; set; }

        public CabañaController(IListadoCabañas listadoCabañas, IAltaCabaña altaCabaña, IBuscarCabaña buscarCabaña)
        {
            ListadoCabañas = listadoCabañas;
            AltaCabaña = altaCabaña;
            BuscarCabaña = buscarCabaña;
        }




        // GET: api/<CabañaController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ListadoCabañas.ObtenerListado());
        }




        // GET api/<CabañaController>/5
        [HttpGet]
        [Route("{id}",Name = "get")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("El id no puede ser negativo");
                }
                CabañaDTO buscada = BuscarCabaña.BuscarPorId(id);
                if (buscada == null)
                {
                    return NotFound($"No existe la cabaña con id {id}");
                }
                return Ok(buscada);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            
            }
        }





        // POST api/<CabañaController>
        [HttpPost]
        public IActionResult Post([FromBody] CabañaDTO? cabaña)
        {
            try
            {
                if (cabaña == null) return BadRequest("No se proporcionó info de cabaña");
                AltaCabaña.Alta(cabaña);
                return CreatedAtRoute("get", new { id = cabaña.Id }, cabaña);
            }
            catch (Exception ex)          
            {
                return StatusCode(500, ex.Message);
            }
        }



        // PUT api/<CabañaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CabañaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
