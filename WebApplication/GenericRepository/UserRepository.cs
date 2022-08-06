using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication.Data;
using WebApplication.Entity;

namespace WebApplication.GenericRepository
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public UserRepository(DataContext context) :base(context)
        {

        }

        public ActionResult<User> MaxAge()
        {
            var user = context.User.OrderByDescending(x=>x.Age).First();
            return user;
        }

        public ActionResult<User> MinAge()
        {

            var user = context.User.OrderBy(x => x.Age).First();
            return user;
        }

      
    }
}
