using System.ComponentModel.DataAnnotations;

namespace SmollanWebAPI.Models.Users
{
    public class UserRequestModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
