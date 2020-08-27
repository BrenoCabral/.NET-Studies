using Microsoft.EntityFrameworkCore;
using SalManager2.Domain.BaseArchitecture;
using SalManager2.Domain.Models;
using SalManager2.Domain.Repositories.Interfaces;
using SalManager2.Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalManager2.Domain.Services
{
    public class MembroService : IMembroService
    {
        private readonly IMembroRepository _membroRepository;
        public MembroService(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }
        public Task Create(Membro membro)
        {
            return _membroRepository.Create(membro);
        }

        public Task CreateMultiple(List<Membro> membros)
        {
            return _membroRepository.CreateMultiple(membros);
        }

        public Task Delete(int id)
        {
            return _membroRepository.Delete(id);
        }

        public Task Update(Membro membro)
        {
            return _membroRepository.Update(membro);
        }

        public List<Membro> GetAll()
        {
            return _membroRepository.GetAll().Include(i=>i.PG).ToList();
        }

        public Task<Membro> GetById(int id)
        {
            return _membroRepository.GetById(id);
        }
    }
}
