using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalManager2.Domain.BaseArchitecture
{
    public interface IService<T>
    {
        List<T> GetAll();
        Task Create(T membro);
        Task CreateMultiple(List<T> entity);
        Task Delete(int id);
        Task Update(T membro);
        Task<T> GetById(int id);
    }
}
