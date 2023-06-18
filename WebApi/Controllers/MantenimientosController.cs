using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientosController : ControllerBase
    {
        // GET: api/<MantenimientosController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/<MantenimientosController>/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        // POST api/<MantenimientosController>
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return CreatedAtRoute("Get", new { id=0}, null);
        }

        // PUT api/<MantenimientosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/<MantenimientosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
