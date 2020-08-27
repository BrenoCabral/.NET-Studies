using SalManager2.Domain.BaseArchitecture;
using SalManager2.Domain.Models;
using SalManager2.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalManager2.Domain.Repositories
{
    public class MembroRepository : GenericRepository<Membro>, IMembroRepository
    {
        public MembroRepository(DatabaseContext databaseContext) : base(databaseContext)
        {}

    }
}
