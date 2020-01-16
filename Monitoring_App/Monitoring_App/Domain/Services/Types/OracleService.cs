using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monitoring_App.Domain.States;
using Oracle.ManagedDataAccess.Client;

namespace Monitoring_App.Domain.Services.Types
{
    public class OracleService : IServiceType
    {
        string connectionString;
        public IState GetState(string communicationEndpoint, string versionEndpoint)
        {
            connectionString = communicationEndpoint;

            return new State()
            {
                IsOnline = IsOnline(),
                Version = GetVersion()
            };
        }

        public bool IsOnline()
        {
            using (var conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    conn.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public string GetVersion()
        {
            OracleConnection conn = new OracleConnection(connectionString);
            try
            {
                conn.Open();
                return conn.ServerVersion;
            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nException thrown. Connection string is not right or the database is not online.");
                return "Version not found.";
            }
            finally
            {
                conn.Close();
            }
            
        }
    }
}
