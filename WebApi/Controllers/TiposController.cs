using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")] //http://localhost:xxxx/api/tipos
    [ApiController]
    public class TiposController : ControllerBase
    {
        // GET: api/<TiposController>
        [HttpGet]
        public IActionResult Get()  //Find all
        {
            return Ok();
        }

        // GET api/<TiposController>/5
        [HttpGet("{id}" , Name = "Get")]
        public IActionResult Get(int id)  //  FindBy Id 
        {
            return Ok();
        }


        [HttpGet("nombre/{texto}")]

        public IActionResult BuscarPorNombre(string texto)  //  FindByName
        {
            return Ok();
        }



        // POST api/<TiposController>
        [HttpPost]
        public IActionResult Post([FromBody] string value)   //Add
        {
            return CreatedAtRoute("Get" , new { id= 0}, null);

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
