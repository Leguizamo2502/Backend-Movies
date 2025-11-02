using Entity.Domain.Models.Base;
using Entity.Infrastructure.Contexs;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class DataGeneric<T> : ADataGeneric<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public DataGeneric(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public override async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet
                .Where(e=>e.IsDeleted == false)
                .ToListAsync();
        }
        public override async Task<IEnumerable<T>> GetDeletes()
        {
            return await _dbSet
                 .Where(e => e.IsDeleted == true)
                 .ToListAsync();
        }

        public override async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet
                .FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted == false);
        }

        public override async Task<T> CreateAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public override async Task<bool> UpdateAsync(T entity)
        {
            var existingEntity = await _dbSet.FindAsync(entity.Id);

            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
            else
            {
                _context.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }

            return await _context.SaveChangesAsync() > 0;
        }
        public override async Task<bool> RestoreAsync(int id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(e=>e.Id == id && e.IsDeleted == true);
            if (entity == null) return false;

            entity.IsDeleted = false;
            return await _context.SaveChangesAsync() > 0;


        }
        public override async Task<bool> DeleteLogicAsync(int id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted == false);
            if (entity == null) return true;

            entity.IsDeleted = false;
            return await _context.SaveChangesAsync() > 0;
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null) return false;

            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }



    }
}
