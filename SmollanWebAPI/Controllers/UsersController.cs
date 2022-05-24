using Microsoft.AspNetCore.Mvc;
using SmollanWebAPI.Models.Users;
using SmollanWebAPI.Services.UserService;

namespace SmollanWebAPI.Controllers
{
    [Route("api/smollan")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("[controller]/{id:int}", Name = "GetUser")]
        public IActionResult GetUser([FromRoute] int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
                return NotFound(new { message = $"No user found with id {id}.", status = StatusCodes.Status404NotFound });

            UserResponseModel model = new()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return Ok(model);
        }

        [HttpGet]
        [Route("[controller]", Name = "GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();

            if (!users.Any())
                return NotFound(new { message = "No users found.", status = StatusCodes.Status404NotFound });

            List<UserResponseModel> model = new();

            foreach (var user in users)
            {
                model.Add(new UserResponseModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                });
            }

            return Ok(model);
        }

        [HttpPost]
        [Route("[controller]", Name = "CreateUser")]
        public IActionResult CreateUser([FromBody] UserRequestModel model)
        {
            _userService.CreateUser(model);

            return Ok(new { message = "The user was created successfully.", status = StatusCodes.Status200OK });
        }

        [HttpPut]
        [Route("[controller]/{id:int}", Name = "UpdateUser")]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] UserRequestModel model)
        {
            var user = _userService.GetById(id);

            if (user == null)
                return NotFound(new { message = $"No user found with id {id}.", status = StatusCodes.Status404NotFound });

            _userService.UpdateUser(user, model);

            return Ok(new { message = "The user was updated successfully.", status = StatusCodes.Status200OK });
        }

        [HttpDelete]
        [Route("[controller]/{id:int}", Name = "DeleteUser")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
                return NotFound(new { message = $"No user was found with id {id}."});

            _userService.DeleteUser(user);

            return Ok(new { message = "The user was deleted successfully.", status = StatusCodes.Status200OK });
        }
    }
}
