using manilab.interfaces;
using manilab.server;
using manilab.WebApp.EFModels;
using System.Web.Http;

namespace manilab.WebApp.Controllers
{
    [Route("api/usercontroller")]
    public class UserController : ApiController
    {
        private readonly IUsersService usersService;
        public UserController()
        {
            usersService = new UsersServices(new ManilabContext());
        }
        // GET: api/User
        public IHttpActionResult Get()
        {
            var result = usersService.GetAll();
            return Ok(result);
        }
    }
}
