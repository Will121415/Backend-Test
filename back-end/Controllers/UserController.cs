using back_end.models;
using BLL;
using DAL;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private UserService _userService;

        public UserController(TestContext testContext)
        {
	        _userService = new UserService(testContext);
        }

        [HttpPost]
        public ActionResult<UserViewModel> Save(UserInputModel userInput)
        {
            var user =  MapUser(userInput);
            var response = _userService.Save(user);
            if (response.Object == null) return BadRequest(response.Message);

            return Ok(new UserViewModel(response.Object));
        }

        private User MapUser(UserInputModel userInput)
        {
            User user = new User();

            user.UserName = userInput.UserName;
            user.Password = userInput.Password;
            user.Role = userInput.Role;
            user.Status = userInput.Status;

            return user;

        }
        
    }
}