using SmollanWebAPI.Entities;
using SmollanWebAPI.Models.Users;

namespace SmollanWebAPI.Services.UserService
{
    public interface IUserService
    {
        User AuthorizeUser(string email,  string password);
        User GetById(int id);
        List<User> GetUsers();
        void CreateUser(UserRequestModel model);
        void UpdateUser(User user, UserRequestModel model);
        void DeleteUser(User user);
    }
}
