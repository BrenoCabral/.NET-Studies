using Microsoft.EntityFrameworkCore;
using SalManager2.Domain.Models;
using SalManager2.Domain.Repositories.Interfaces;
using SalManager2.Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalManager2.Domain.Services
{
    public class PGService : IPGService
    {
        private readonly IPGRepository _PGRepository;
        public PGService(IPGRepository PGRepository)
        {
            _PGRepository = PGRepository;
        }
        public Task Create(PG PG)
        {
            return _PGRepository.Create(PG);
        }

        public Task CreateMultiple(List<PG> PGs)
        {
            return _PGRepository.CreateMultiple(PGs);
        }

        public Task Delete(int id)
        {
            return _PGRepository.Delete(id);
        }

        public Task Update(PG PG)
        {
            return _PGRepository.Update(PG);
        }

        public List<PG> GetAll()
        {
            return _PGRepository.GetAll().Include(i => i.Membros).ToList();
        }

        public Task<PG> GetById(int id)
        {
            return _PGRepository.GetById(id);
        }
    }
}
