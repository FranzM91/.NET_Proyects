using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using uab.server.Business;
using uab.server.Entities;
using uab.server.webapp.Models;

namespace uab.server.webapp.Controllers
{
    [RoutePrefix("api/todoapp")]
    public class TodoAppController : ApiController
    {
        //private readonly TodoAppBusiness todoAppBusiness;
        public TodoAppController()
        {
            //todoAppBusiness = new TodoAppBusiness();
        }

        [HttpGet]
        [Route("getbyfilter/{filter}")]
        public IHttpActionResult GetByFilter(string filter)
        {
            var result = new List<LiteGeneroModel>()
            {
                new LiteGeneroModel()
                {
                    id = 1,
                    nombre = "Teclado"
                },
                new LiteGeneroModel()
                {
                    id = 2,
                    nombre = "Monitor DELL"
                },
                new LiteGeneroModel()
                {
                    id = 3,
                    nombre = "Monitor ASUS"
                },
                new LiteGeneroModel()
                {
                    id = 4,
                    nombre = "Cargador 19v"
                },
                new LiteGeneroModel()
                {
                    id = 5,
                    nombre = "CPU Core i7"
                },
                new LiteGeneroModel()
                {
                    id = 6,
                    nombre = "CPU Core i3"
                }
            };

            result.Where(src => src.nombre.Contains(filter));
            return Ok(result);
        }

        //[HttpPost]
        //[Route("getbyid")]
        //public IHttpActionResult RetornarTodoApp(int entityId)
        //{
        //    var resultado = todoAppBusiness.GetById(entityId) ?? new TodoApp();
        //    if(resultado.Id == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(resultado);
        //}

        //[HttpPost]
        //[Route("save")]
        //public IHttpActionResult Save(TodoApp dato)
        //{
        //    if(dato.Id == 0)
        //    {
        //        dato.FechaCreacion = DateTime.Now;
        //    }
        //    dato.FechaActualizacion = DateTime.Now;
        //    var result = todoAppBusiness.SaveOrUpdate(dato);
        //    return Ok(result);
        //}

        //[HttpPost]
        //[Route("update")]
        //public IHttpActionResult Update()
        //{
        //    return Ok("actualizdo corretamente!!!");
        //}
        //[HttpPost]
        //[Route("delete")]
        //public IHttpActionResult Delete(int entityId)
        //{
        //    todoAppBusiness.DeleteById(entityId);
        //    return Ok("Se elimino corretamente!!!");
        //}

        //[HttpPost]
        //[Route("serachbydescription")]
        //public IHttpActionResult SearchByDescrition(string description)
        //{
        //    var resultado = todoAppBusiness.SearchByDescription(description);
        //    var sexousuario = resultado.FirstOrDefault().Usuario.Sexo.ToString(); 
        //    return Ok(resultado);
        //}

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
