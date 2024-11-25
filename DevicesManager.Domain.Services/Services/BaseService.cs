using DevicesManager.Domain.Core.Interfaces.Repositories;
using DevicesManager.Domain.Core.Interfaces.Services;

namespace DevicesManager.Domain.Services.Services
{
    public abstract class BaseService<TEntity>(IBaseRepository<TEntity> Repository) : IDisposable, IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository = Repository;

        public virtual void Add(TEntity obj)
            => _repository.Add(obj);

        public virtual TEntity GetById(int id)
            => _repository.GetById(id);

        public virtual IEnumerable<TEntity> GetAll()
            => _repository.GetAll();

        public virtual void Update(TEntity obj)
            => _repository.Update(obj);

        public virtual void Delete(int id)
            => _repository.Delete(id);

        public virtual void Dispose()
            => _repository.Dispose();
    }
}
