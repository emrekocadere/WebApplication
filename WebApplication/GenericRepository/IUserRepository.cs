using Microsoft.AspNetCore.Mvc;
using WebApplication.Entity;

namespace WebApplication.GenericRepository
{
    public interface IUserRepository:IGenericRepository<User>    {
        ActionResult<User> MaxAge();
        ActionResult<User> MinAge();


    }
}
