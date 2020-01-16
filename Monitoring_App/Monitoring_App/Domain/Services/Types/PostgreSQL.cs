using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monitoring_App.Domain.States;
using Npgsql;

namespace Monitoring_App.Domain.Services.Types
{
    public class PostgreSQL : IServiceType
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
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connectionString);
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Success open postgreSQL connection.");
                    conn.Close();
                    return true;
                }
                return false;
            }
            catch
            {
                Console.WriteLine("\r\n Exception Raised. The connection string is not valid or the service is offline");
                return false;
            }           
                
        }

        public string GetVersion()
        {
            try
            {
                string version = string.Empty;
                NpgsqlConnection conn = new NpgsqlConnection(connectionString);
                var command = new NpgsqlCommand("SELECT version()", conn);
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    version = (string)command.ExecuteScalar();
                }
                conn.Close();

                return version;
            }
            catch
            {
                Console.WriteLine("\r\nException thrown. Connection string is not right or the database is not online.");
                return "Version not found.";
            }
            
        }
    }
}
