namespace SmartHotels.Data.SeedWork
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(int id);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        Task Delete(int id);
    }
}
