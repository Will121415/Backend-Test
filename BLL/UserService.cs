using System;
using System.Linq;
using DAL;
using Entity;

namespace BLL
{
    public class UserService
    {
         private readonly TestContext _context;
        public UserService(TestContext testContext)=> _context = testContext;
        public Response<User> Validate(string userName, string password) 
        {
            try
            {
                var user = _context.Users.
                            FirstOrDefault(t => t.UserName == userName && t.Password == password
                             && t.Status == "Active");

                return new Response<User>(user);

            } catch(Exception e)
            {
                return new  Response<User>($"Error de aplicacion: {e.Message}");
            }
        }
    }
}