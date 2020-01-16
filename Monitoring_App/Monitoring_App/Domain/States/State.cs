using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring_App.Domain.States
{
    public class State : IState
    {
        public bool IsOnline { get; set; }
        public string Version { get; set; }
    }
}
