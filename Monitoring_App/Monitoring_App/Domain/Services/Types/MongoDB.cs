using System;
using Microsoft.Data.SqlClient;
using Monitoring_App.Domain.States;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Monitoring_App.Domain.Services.Types
{
    public class MongoDBService : IServiceType
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
                var db = GetDatabase();
                var online = db.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(5000);
                return online; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("\r\n Exception Raised. The connection string is not valid or the service is offline");
                return false;
            }
        }

        public string GetVersion()
        {
            try
            {
                var db = GetDatabase();
                var serverStatusCmd = new BsonDocumentCommand<BsonDocument>(new BsonDocument { { "serverStatus", 1 } });
                var result = db.RunCommand(serverStatusCmd);
                return result["version"].ToString();
            }
            catch(Exception e)
            {
                Console.WriteLine("\r\nException thrown. Connection string is not right or the database is not online.");
                return "Version not found.";
            }
            
        }

        private IMongoDatabase GetDatabase()
        {
            var client = new MongoClient(connectionString);
            string databaseName = connectionString.Substring(14, connectionString.LastIndexOf(':')-14);
            return client.GetDatabase(databaseName);
        }
        
    }
}
