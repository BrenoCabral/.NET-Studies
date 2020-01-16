using Monitoring_App.Domain.Services.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring_App.Domain.Factories
{
    public class ServiceTypeFactory
    {
        public static IServiceType Create(string type)
        {
            IServiceType serviceType = (IServiceType)Activator.CreateInstance(ObtenhaImplementacao(type));
            return serviceType;
        }
        private static Type ObtenhaImplementacao(string type)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                                       .Where(x => !x.IsDynamic)
                                       .SelectMany(x => x.ExportedTypes)
                                       .Where(x => x.IsSubclassOf(typeof(IServiceType)))
                                       .Where(x => x.Name.Equals(type, StringComparison.InvariantCultureIgnoreCase))
                                       .FirstOrDefault();

        }
    }

}
