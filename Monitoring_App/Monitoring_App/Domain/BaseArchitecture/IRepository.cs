using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring_App.Domain.BaseArchitecture
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
    }
}
