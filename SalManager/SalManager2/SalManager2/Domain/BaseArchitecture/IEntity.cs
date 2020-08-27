using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalManager2.Domain.BaseArchitecture
{
    public interface IEntity
    {
        int Id { get; set; }
    }
}
