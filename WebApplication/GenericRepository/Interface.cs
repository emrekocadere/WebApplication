namespace WebApplication.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Select(TEntity entity);   
    }
}
