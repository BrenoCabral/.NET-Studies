using Monitoring_App.Domain.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring_App.Domain.Services.Types
{
    public interface IServiceType
    {
        IState GetState(string communicationEndpoint, string versionEndpoint);
        string GetVersion(); 
        bool IsOnline();
    }
}
