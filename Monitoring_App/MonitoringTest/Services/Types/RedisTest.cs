using Monitoring_App.Domain.Services.Types;
using Monitoring_App.Domain.States;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringTest.Services
{
    class RedisTest
    {
        Redis redis = new Redis();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsOnlineTrue()
        {
            redis.GetState("redis-session.ux8vz5.ng.0001.use1.cache.amazonaws.com:6379", "");

            Assert.IsTrue(redis.IsOnline());
        }
        [Test]
        public void IsOnlineFalse()
        {
            redis.GetState("redis-session.ux8vz5.ngg.0001.use1.cache.amazonaws.com:6379", "");

            Assert.IsFalse(redis.IsOnline());
        }
        [Test]
        public void GetStateOnline()
        {
            State stateTested = (State)redis.GetState("redis-session.ux8vz5.ng.0001.use1.cache.amazonaws.com:6379", "");

            Assert.That(stateTested.Version is string && stateTested.IsOnline, "The version is not a string or the IsOnline is false");
        }
        [Test]
        public void GetStateOffline()
        {
            State stateTested = (State)redis.GetState("redis-session.ux8vz5.ngg.0001.use1.cache.amazonaws.com:6379", "");

            Assert.That(stateTested.Version is string && !stateTested.IsOnline, "The version is not a string or the IsOnline is true");
        }

        [Test]
        public void GetVersionRight()
        {
            redis.GetState("redis-session.ux8vz5.ng.0001.use1.cache.amazonaws.com:6379", "");
            Assert.AreEqual("5.0.0", redis.GetVersion());
        }

        [Test]
        public void GetVersionWrong()
        {
            redis.GetState("redis-session.ux8vz5.ngg.0001.use1.cache.amazonaws.com:6379", "");

            Assert.AreEqual("Version not found.", redis.GetVersion());
        }
    }
}
