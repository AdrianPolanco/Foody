using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Foody.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Policy = "RequireWaiterRole")]
    public class TableController : ControllerBase
    {
        // GET: api/<TableController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TableController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TableController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TableController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TableController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
