using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Entity;
namespace WebApplication.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        readonly protected DataContext context;
        private DbSet<TEntity> table;
        
        public GenericRepository(DataContext context)
        {
            this.context = context;
            table=this.context.Set<TEntity>();

    }

    public void Delete(TEntity entity)
        {

        }

        public void Insert(TEntity entity)
        {
            table.Add(entity);
            context.SaveChanges();
        }

        public void Select(TEntity entity)
        {
            table.Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
