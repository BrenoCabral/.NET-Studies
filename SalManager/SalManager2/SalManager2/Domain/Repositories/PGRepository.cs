using Microsoft.EntityFrameworkCore;
using SalManager2.Domain.BaseArchitecture;
using SalManager2.Domain.Models;
using SalManager2.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalManager2.Domain.Repositories
{
    public class PGRepository : GenericRepository<PG>, IPGRepository
    {
        DatabaseContext _databaseContext;
        public PGRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public new async Task<PG> GetById(int id)
        {
            return await _databaseContext.Set<PG>().Where(w=> w.Id==id).Include(i => i.Membros).FirstOrDefaultAsync();
        }

    }
}
