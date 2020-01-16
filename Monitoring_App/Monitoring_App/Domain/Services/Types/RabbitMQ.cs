using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monitoring_App.Domain.States;
using RabbitMQ.Client;

namespace Monitoring_App.Domain.Services.Types
{
    public class RabbitMQService : IServiceType
    {
        string connectionString;
        ConnectionFactory factory;
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
            factory = new ConnectionFactory();
            factory.Uri = new Uri(connectionString);
            try
            {
                IConnection conn = factory.CreateConnection();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }

            
        }

        public string GetVersion()
        {
            factory = new ConnectionFactory();
            factory.Uri = new Uri(connectionString);
            try
            {
                IConnection conn = factory.CreateConnection();
                IDictionary<string, object> properties = conn.ServerProperties;
                var byteVersion = (byte[]) properties["version"];
                var stringVersion = System.Text.Encoding.UTF8.GetString((byte[])properties["version"]);

                return stringVersion;
            }
            catch(Exception e)
            {
                return "Version not found.";
            }

        }
    }
}
