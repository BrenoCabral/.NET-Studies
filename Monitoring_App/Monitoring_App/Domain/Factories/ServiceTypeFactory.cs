using Monitoring_App.Domain.Services.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring_App.Domain.Factories
{
    public class ServiceTypeFactory
    {
        internal static void InitiateTypes()
        {
            Types = CreateTypes();
        }

        private static List<Type> Types;
        public static IServiceType Create(string type)
        {
            try
            {
                IServiceType serviceType = (IServiceType)Activator.CreateInstance(ObtenhaImplementacao(type));
                return serviceType;
            }
            catch(Exception e)
            {
                throw new Exception("O tipo passado não existe.");
            }
            
        }
        private static Type ObtenhaImplementacao(string type)
        {
            try
            {
                Type typeFound = Types.Where(x => x.GetInterfaces().Contains(typeof(IServiceType)))
                        .Where(x => x.Name.Equals(type, StringComparison.InvariantCultureIgnoreCase)).
                        FirstOrDefault();
                return typeFound;
            }
            catch
            {
                throw new Exception("Implementação não foi encontrada.");
            }
        }

        private static List<Type> CreateTypes()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                                       .Where(x => !x.IsDynamic)
                                       .SelectMany(x => x.ExportedTypes)
                                       .ToList();
        }
    }

}
