using DevicesManager.Domain.Core.Interfaces.Repositories;
using DevicesManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DevicesManager.Infrastruture.Repository.Repositories
{
    public abstract class BaseRepository<TEntity>(DevicesDBContext Context) : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DevicesDBContext _context = Context;

        public virtual void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        public virtual TEntity? GetById(int id)
            => _context.Set<TEntity>().Find(id);

        public virtual IEnumerable<TEntity> GetAll()
            => [.. _context.Set<TEntity>().AsNoTracking()];

        public virtual void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        public virtual void Delete(int id)
        {
            var obj = _context.Set<TEntity>().Find(id);
            if (obj != null) {
                _context.Set<TEntity>().Remove(obj);
                _context.SaveChanges();
                _context.ChangeTracker.Clear();
            }
        }

        public virtual void Dispose()
            => _context.Dispose();
    }
}
