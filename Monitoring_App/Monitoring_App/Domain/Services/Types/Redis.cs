using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monitoring_App.Domain.States;
using StackExchange.Redis;

namespace Monitoring_App.Domain.Services.Types
{
    public class Redis : IServiceType
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
                ConnectionMultiplexer conn = ConnectionMultiplexer.Connect(connectionString);
                if (conn.IsConnected)
                {
                    return true;
                }
                return false;
            }catch(Exception e)
            {
                Console.WriteLine("There was a problem when getting the Redis connection. Or the service ie offline or the connection string is not right.");
                return false;
            }
            
        }

        public string GetVersion()
        {
            try
            {
                string version = string.Empty;
                ConnectionMultiplexer conn = ConnectionMultiplexer.Connect(connectionString);
                if (conn.IsConnected)
                {
                    var endpoints = conn.GetEndPoints();
                    var hasEndpoint = endpoints != null && endpoints.Any();
                    version = hasEndpoint? conn.GetServer(endpoints[0]).Version.ToString(): "Version not found.";
                }

                return version;
            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem when getting the Redis connection. Or the service ie offline or the connection string is not right.");
                return "Version not found.";
            }
        }
    }
}
