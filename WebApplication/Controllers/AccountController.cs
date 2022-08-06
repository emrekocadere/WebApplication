using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WebApplication.Data;
using WebApplication.DTOs;
using WebApplication.Entity;
using WebApplication.GenericRepository;

namespace WebApplication.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class AccountController:ControllerBase
    {
        private readonly DataContext context1;
        private readonly IUserRepository repository;
        public AccountController(DataContext context,IUserRepository repository)
        {
            this.context = context;
            this.repository = repository;

           
        }
        private DataContext context = new DataContext();


        [HttpPost("register")]
         public ActionResult<User>Register(UserDto dto)
        {
            
            if(UserExists(dto.Name)==true)
            {
                return Unauthorized("Invalid Username");
            }
            var hmac = new HMACSHA512();//bak
            User user = new User()
            {
                Name = dto.Name,
                SurName = dto.Surname,
                HashPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.PassWord)),
                Salt = hmac.Key,
                Age = dto.Age
            };

            repository.Insert(user);

            return user;

        }

        [HttpPost("login")]
        public ActionResult<User>Login(UserDto dto)
        {
            var user = context.User.SingleOrDefault(x => x.Name == dto.Name);
            if(user == null)
            {
                return Unauthorized("Invalid Username");
            }
            var hmac=new HMACSHA512(user.Salt);
            var ComputedHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.PassWord));
            for(int i=0;i<ComputedHash.Length ;i++)
            {
                if (ComputedHash[i] != user.HashPassword[i])//Computed has==user.HashPassword
                {
                    return Unauthorized("Invalid Password");
                }
               
            }
            return user;
        }

        private bool UserExists(string name)
        {
            return context.User.Any(x => x.Name == name);
        }
    }
}
