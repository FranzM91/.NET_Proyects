using Microsoft.AspNetCore.Mvc;
using uab.server.Business;
using uab.server.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace uab.server.webapp.Controllers
{
    [Route("api/todoapp")]
    [ApiController]
    public class TodoAppController : ControllerBase
    {
        private readonly TodoAppBusiness todoAppBusiness;
        public TodoAppController()
        {
            todoAppBusiness = new TodoAppBusiness();
        }
        // GET: api/<TodoAppController>
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var resultado = todoAppBusiness.GetById(1008);
        //    return Ok(resultado);
        //}
        [Route("getbyid")]
        [HttpPost]
        public IActionResult GetById(int entityId)
        {
            var resultado = todoAppBusiness.GetById(entityId) ?? new TodoApp();
            if(resultado.Id == 0)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        [Route("save")]
        [HttpPost]
        public IActionResult Save(string dataName)
        {
            return Ok(dataName);
        }

        [Route("update")]
        [HttpPost]
        public IActionResult Update()
        {
            return Ok("actualizdo corretamente!!!");
        }

        //// GET api/<TodoAppController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<TodoAppController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<TodoAppController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<TodoAppController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
