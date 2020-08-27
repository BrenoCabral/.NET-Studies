using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monitoring_App.Domain.States;
using RabbitMQ.Client;

namespace Monitoring_App.Domain.Services.Types
{
    public class RabbitMQService : IServiceType
    {
        ConnectionFactory _factory;
        IConnection _connection;
        private static ConcurrentDictionary<string, ConnectionFactory> FactoryList { get; set; } = new ConcurrentDictionary<string, ConnectionFactory>();
        private static ConcurrentDictionary<Uri, IConnection> ConnectionList { get; set; } = new ConcurrentDictionary<Uri, IConnection>();
        public ConnectionFactory GetFactory(string communicationEndpoint) =>
                FactoryList.GetOrAdd(communicationEndpoint, (string communicationEndpoint) =>
                 new ConnectionFactory() { Uri = new Uri(communicationEndpoint) });

        public IConnection GetConnection(ConnectionFactory factory) => ConnectionList.GetOrAdd(factory.Uri, (Uri uri) => factory.CreateConnection());

        public IState GetState(string communicationEndpoint, string versionEndpoint)
        {
            try
            {
                _factory = GetFactory(communicationEndpoint);
                _connection = GetConnection(_factory);

                return new State()
                {
                    IsOnline = IsOnline(),
                    Version = GetVersion()
                };
            }
            catch
            {
                return OfflineState();
            }
        }
        public bool IsOnline()
        {
            try
            {
                return _connection.IsOpen;
            }
            catch
            {
                return false;
            }
        }
        public string GetVersion()
        {
            try
            {
                IDictionary<string, object> properties = _connection.ServerProperties;
                var byteVersion = (byte[])properties["version"];
                var stringVersion = System.Text.Encoding.UTF8.GetString((byte[])properties["version"]);

                return stringVersion;
            }
            catch (Exception e)
            {
                return "Version not found.";
            }

        }
        private static State OfflineState()
        {
            return new State()
            {
                IsOnline = false,
                Version = "Version not found."
            };
        }
    }
}
