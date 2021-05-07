using System.ComponentModel.DataAnnotations;
using Entity;

namespace back_end.models
{
    public class LoginInputModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class LoginViewModel: LoginInputModel
    {
        public string Status { get; set; }
        public string Role { get; set; }

        public LoginViewModel() {}

        public LoginViewModel(User user) 
        {
            UserName = user.UserName;
            Password = user.Password;
            Status = user.Status;
            Role = user.Role;
        }
    }
}