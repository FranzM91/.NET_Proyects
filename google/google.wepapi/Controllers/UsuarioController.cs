using google.server.Business;
using Microsoft.AspNetCore.Mvc;

namespace google.wepapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioBusiness usuarioBusiness;
        private readonly PingSchedulerBusiness schedulerBusiness;
        public UsuarioController(ILogger<WeatherForecastController> logger)
        {
            usuarioBusiness = new UsuarioBusiness();
            schedulerBusiness = new PingSchedulerBusiness();
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var result = usuarioBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("start")]
        public IActionResult StartService()
        {
            schedulerBusiness.Start();
            return Ok();
        }
    }
}
