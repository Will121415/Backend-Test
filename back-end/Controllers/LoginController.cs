using back_end.models;
using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]

    public class LoginController: ControllerBase
    {
        private UserService _userService;

        public LoginController(TestContext testContext)
        {
	        _userService = new UserService(testContext);
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginInputModel model)
        {
            var response = _userService.Validate(model.UserName, model.Password);
            if (response.Object == null) return BadRequest("Username or password is incorrect");
            return Ok(new LoginViewModel(response.Object));
        }


    }
}