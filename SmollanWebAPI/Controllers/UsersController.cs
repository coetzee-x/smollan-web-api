using Microsoft.AspNetCore.Mvc;
using SmollanWebAPI.Models.Users;

namespace SmollanWebAPI.Controllers
{
    [Route("api/smollan")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("[controller]/{id:int}", Name = "GetUser")]
        public IActionResult GetUser(int id)
        {
            return new JsonResult(id);
        }

        [HttpGet]
        [Route("[controller]", Name = "GetUsers")]
        public IActionResult GetUsers()
        {
            var users = new {  firstname =  "Xander", lastname = "Coetzee", email = "coetzeex@outlook.com" };

            return new JsonResult(users);
        }

        [HttpPost]
        [Route("[controller]", Name = "CreateUser")]
        public IActionResult CreateUser([FromBody] UserRequestModel model)
        {
            return new JsonResult(model);
        }

    }
}
