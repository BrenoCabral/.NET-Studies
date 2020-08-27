using Monitoring_App.Domain.Services.Types;
using Monitoring_App.Domain.States;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringTest.Services
{
    class RabbitMQTest
    {
        RabbitMQService rabbitMQ = new RabbitMQService();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsOnlineTrue()
        {
            State stateTested = (State)rabbitMQ.GetState("amqp://zarsynha:qIJywNpw9ZACJ_jFWvesD71mntWp4v_w@rhino.rmq.cloudamqp.com/zarsynha", "");

            Assert.IsTrue(stateTested.IsOnline);
        }
        [Test]
        public void IsOnlineFalse()
        {
            State stateTested = (State)rabbitMQ.GetState("amqp://zarsynha:qIJywNpw9ZACJ_jFWvesD71mntWp4v_w@rhino.rmqq.cloudamqp.com/zarsynha", "");

            Assert.IsFalse(stateTested.IsOnline);
        }
        [Test]
        public void GetStateOnline()
        {
            State stateTested = (State)rabbitMQ.GetState("amqp://zarsynha:qIJywNpw9ZACJ_jFWvesD71mntWp4v_w@rhino.rmq.cloudamqp.com/zarsynha", "");

            Assert.That(stateTested.Version is string && stateTested.IsOnline, "The version is not a string or the IsOnline is false");
        }
        [Test]
        public void GetStateOffline()
        {
            State stateTested = (State)rabbitMQ.GetState("amqp://zarsynha:qIJywNpw9ZACJ_jFWvesD71mntWp4v_w@rhino.rmqq.cloudamqp.com/zarsynha", "");

            Assert.That(stateTested.Version is string && !stateTested.IsOnline, "The version is not a string or the IsOnline is true");
        }

        [Test]
        public void GetVersionRight()
        {
            State stateTested = (State)rabbitMQ.GetState("amqp://zarsynha:qIJywNpw9ZACJ_jFWvesD71mntWp4v_w@rhino.rmq.cloudamqp.com/zarsynha", "");
            Assert.AreEqual("3.6.16", stateTested.Version);
        }

        [Test]
        public void GetVersionWrong()
        {
            State stateTested = (State)rabbitMQ.GetState("amqp://zarsynha:qIJywNpw9ZACJ_jFWvesD71mntWp4v_w@rhino.rmqq.cloudamqp.com/zarsynha", "");

            Assert.AreEqual("Version not found.", stateTested.Version);
        }
    }
}
