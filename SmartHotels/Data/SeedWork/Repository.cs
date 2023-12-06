using Microsoft.EntityFrameworkCore;
using SmartHotels.Infrastructure.Models;

namespace SmartHotels.Data.SeedWork
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly SmartHotelContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(SmartHotelContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var dataToDelete = await _dbSet.FindAsync(id);
            _dbSet.Remove(dataToDelete);
        }

        public async Task<TEntity> Get(int id)
        {
            TEntity entityData = await _dbSet.FindAsync(id);
            return entityData;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            IEnumerable<TEntity> lstData = await _dbSet.ToListAsync();
            return lstData;
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
