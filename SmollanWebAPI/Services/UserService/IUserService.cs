using SmollanWebAPI.Entities;

namespace SmollanWebAPI.Services.UserService
{
    public interface IUserService
    {
        User GetById(int id);
        IEnumerable<User> GetUsers();
        bool CreateUser();
    }
}
