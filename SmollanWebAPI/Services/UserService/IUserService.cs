using SmollanWebAPI.Entities;
using SmollanWebAPI.Models.Users;

namespace SmollanWebAPI.Services.UserService
{
    public interface IUserService
    {
        User GetById(int id);
        List<User> GetUsers();
        void CreateUser(UserRequestModel model);
        void UpdateUser(User user, UserRequestModel model);
    }
}
