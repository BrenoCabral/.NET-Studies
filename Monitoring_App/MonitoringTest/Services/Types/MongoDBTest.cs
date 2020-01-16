using Monitoring_App.Domain.Services.Types;
using Monitoring_App.Domain.States;
using NUnit.Framework;

namespace MonitoringTest.Services
{
    class MongoDBTest
    {
        MongoDBService mongo = new MongoDBService();
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsOnlineTrue()
        {
            mongo.GetState("mongodb+srv://maxleitor:87349@prod-yuqsf.mongodb.net/test?retryWrites=true&w=majority", "");

            Assert.IsTrue(mongo.IsOnline());
        }
        [Test]
        public void IsOnlineFalse()
        {
            mongo.GetState("mongodb+srv://maxleitor:87349@prod-yuqsf.mongodd.net/test?retryWrites=true&w=majority", "");

            Assert.IsFalse(mongo.IsOnline());
        }
        [Test]
        public void GetStateOnline()
        {
            State stateTested = (State)mongo.GetState("mongodb+srv://maxleitor:87349@prod-yuqsf.mongodb.net/test?retryWrites=true&w=majority", "");

            Assert.That(stateTested.Version is string && stateTested.IsOnline, "The version is not a string or the IsOnline is false");
        }
        [Test]
        public void GetStateOffline()
        {
            State stateTested = (State)mongo.GetState("mongodb+srv://maxleitor:87349@prod-yuqsf.mongodd.net/test?retryWrites=true&w=majority", "");

            Assert.That(stateTested.Version is string && !stateTested.IsOnline, "The version is not a string or the IsOnline is true");
        }

        [Test]
        public void GetVersionRight()
        {
            mongo.GetState("mongodb+srv://maxleitor:87349@prod-yuqsf.mongodb.net/test?retryWrites=true&w=majority", "");
            Assert.AreEqual("4.0.14", mongo.GetVersion());
        }

        [Test]
        public void GetVersionWrong()
        {
            mongo.GetState("mongodb+srv://maxleitor:87349@prod-yuqsf.mongodd.net/test?retryWrites=true&w=majority", "");

            Assert.AreEqual("Version not found.", mongo.GetVersion());
        }
    }
}
