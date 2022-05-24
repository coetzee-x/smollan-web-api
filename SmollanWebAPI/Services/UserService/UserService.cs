using SmollanWebAPI.Context;
using SmollanWebAPI.Entities;
using SmollanWebAPI.Models.Users;
using SmollanWebAPI.Services.EncryptService;

namespace SmollanWebAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private DatabaseContext _context;

        private IEncryptService _encryptService;

        public UserService
            (
            DatabaseContext context,
            IEncryptService encryptService
            )
        {
            _context = context;
            _encryptService = encryptService;
        }

        public void CreateUser(UserRequestModel model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = _encryptService.EncryptString(model.Password)
            };

            _context.Users.Add(user);

            _context.SaveChanges();
        }

        public void UpdateUser(User user, UserRequestModel model)
        {
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = user.Email;
            user.Password = _encryptService.EncryptString(model.Password);

            _context.Users.Update(user);

            _context.SaveChanges();
        }

        public User GetById(int id) => _context.Users.FirstOrDefault(f => f.Id == id);

        public List<User> GetUsers() => _context.Users.ToList();
    }
}
