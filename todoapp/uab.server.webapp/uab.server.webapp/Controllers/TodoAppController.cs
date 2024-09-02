using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using uab.server.Business;
using uab.server.Entities;

namespace uab.server.webapp.Controllers
{
    [RoutePrefix("api/todoapp")]
    public class TodoAppController : ApiController
    {
        private readonly TodoAppBusiness todoAppBusiness;
        public TodoAppController()
        {
            todoAppBusiness = new TodoAppBusiness();
        }

        [HttpPost]
        [Route("getbyid")]
        public IHttpActionResult RetornarTodoApp(int entityId)
        {
            var resultado = todoAppBusiness.GetById(entityId) ?? new TodoApp();
            if(resultado.Id == 0)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save(string dataName)
        {
            return Ok(dataName);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult Update()
        {
            return Ok("actualizdo corretamente!!!");
        }

        //// GET: api/TodoApp
        //public IHttpActionResult Get()
        //{
        //    var resultado = todoAppBusiness.GetById(1008);
        //    return Ok(resultado);
        //}

        //// GET: api/TodoApp/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/TodoApp
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/TodoApp/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/TodoApp/5
        //public void Delete(int id)
        //{
        //}
    }
}
