using System.ComponentModel.DataAnnotations;

namespace Blue360Media.Entities
{
    public class Register
    {
        public int UserId { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserAddedOn { get; set; }
        public bool IsActive { get; set; }

        public string RoleId { get; set; }
        public string RoleName { get; set; }

    }
}
