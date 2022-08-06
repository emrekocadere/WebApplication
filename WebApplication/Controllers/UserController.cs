using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Data;
using WebApplication.Entity;
using WebApplication.GenericRepository;

namespace WebApplication.Controllers
{
    [Controller]
    [Route("api/controller")]
    public class UserController:ControllerBase
    {
        IUserRepository repository;
        public UserController(IUserRepository repository)//sro neden interface
        {
            this.repository = repository;
        }
        [HttpGet("maxage")]
        public ActionResult<User>maxage()
        {
            return repository.MaxAge();
        }
        [HttpGet("minage")]
        public ActionResult<User> minage()
        {
            
            return repository.MinAge();
        }
    }
}
