using Microsoft.AspNetCore.Mvc;
using uab.server.Business;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationTodoApp.Controllers
{
    [Route("api/todoapp")]
    [ApiController]
    public class TodoAppController : ControllerBase
    {
        public readonly TodoAppBusiness todoAppBusiness;
        public TodoAppController()
        {
            todoAppBusiness = new TodoAppBusiness();
        }
        // GET: api/<TodoAppController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = todoAppBusiness.GetById(5);
            return Ok(result);
        }

        // GET api/<TodoAppController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TodoAppController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TodoAppController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodoAppController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
