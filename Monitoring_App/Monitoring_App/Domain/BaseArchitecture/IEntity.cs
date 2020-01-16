using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring_App.Domain.BaseArchitecture
{
    public interface IEntity
    {
        int Id { get; set; }
    }
}
