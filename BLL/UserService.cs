using System;
using System.Linq;
using DAL;
using Entity;
using Infrastructure;

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
                            FirstOrDefault(t => t.UserName == userName && t.Password == Hash.GetSha256(password)
                             && t.Status == "Active");

                return new Response<User>(user);
                
            } catch(Exception e)
            {
                return new  Response<User>($"Error de aplicacion: {e.Message}");
            }
        }

        public Response<User> Save(User user) {
            try {
                var _user = _context.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();

                if (_user != null)  return new Response<User>("El usuario ya se encuentra registrado");
                
                user.Password =  Hash.GetSha256(user.Password);
                _context.Users.Add(user);
                _context.SaveChanges();
                
                return new Response<User>(user);

            }catch(Exception e)
            {
                return new Response<User>($"Error de aplicacion: {e.Message}");
            }
        }


    }
}