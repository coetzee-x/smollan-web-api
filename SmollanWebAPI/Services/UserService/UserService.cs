using Microsoft.Extensions.Caching.Memory;
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
        private IMemoryCache _memoryCache;

        public UserService
            (
            DatabaseContext context,
            IEncryptService encryptService,
            IMemoryCache memoryCache
            )
        {
            _context = context;
            _encryptService = encryptService;
            _memoryCache = memoryCache;
        }

        public User AuthorizeUser(string email, string password)
        {
            var encryptedPassword = _encryptService.EncryptString(password);

            var user = _context.Users.FirstOrDefault(f => f.Email == email && f.Password == encryptedPassword);

            return user;
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
            user.Email = model.Email;
            user.Password = _encryptService.EncryptString(model.Password);

            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);

            _context.SaveChanges();
        }

        public User GetById(int id)
        {
            if (!_memoryCache.TryGetValue($"user:{id}", out User user))
            {
                user = _context.Users.FirstOrDefault(f => f.Id == id);

                if(user != null)
                    _memoryCache.Set($"user:{id}", user);
            }

            return user;
        }
        public List<User> GetUsers() => _context.Users.ToList();
    }
}
