using Microsoft.EntityFrameworkCore;
using WebApplication.Data;

namespace WebApplication.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private DataContext context = new DataContext();
        private DbSet<TEntity> table;
        
        public GenericRepository()
        {
            table=context.Set<TEntity>();

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
