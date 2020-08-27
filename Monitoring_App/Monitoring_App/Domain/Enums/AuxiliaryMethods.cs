using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring_App.Domain.Enums
{
    public class AuxiliaryMethods
    {
        public static T GetEnumFromString<T>(string enumString)
        {
            try
            {
                T myEnum = (T)Enum.Parse(typeof(T), enumString);
                return myEnum;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error acurred when converting string to ENUM. Error:" + e.Message);
                throw e;
            }

        }
    }
}
