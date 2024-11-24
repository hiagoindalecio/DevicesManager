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
            try
            {
                _context.Set<TEntity>().Add(obj);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return [.. _context.Set<TEntity>()];
        }

        public virtual void Update(TEntity obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Remove(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}
