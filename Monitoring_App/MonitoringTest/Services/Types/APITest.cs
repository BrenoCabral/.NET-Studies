using Monitoring_App.Domain.Services.Types;
using Monitoring_App.Domain.States;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringTest.Services
{
    class APITest
    {
        API api = new API();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsOnlineTrue()
        {
            api.GetState("http://serverpdvv.solucoesmaxima.com.br:8081/swagger", "http://serverpdvv.solucoesmaxima.com.br:8081/v1/GetVersion");

            Assert.IsTrue(api.IsOnline());
        }
        [Test]
        public void IsOnlineFalse()
        {
            api.GetState("http://serverpdvv.solucoesmaximas.com.br:8081/swagger", "http://serverpdvv.solucoesmaxima.com.br:8081/v1/GetVersion");

            Assert.IsFalse(api.IsOnline());
        }
        [Test]
        public void GetStateOnline()
        {
            State stateTested = (State)api.GetState("http://serverpdvv.solucoesmaxima.com.br:8081/swagger", "http://serverpdvv.solucoesmaxima.com.br:8081/v1/GetVersion");

            Assert.That(stateTested.Version is string && stateTested.IsOnline, "The version is not a string or the IsOnline is false");
        }
        [Test]
        public void GetStateOffline()
        {
            State stateTested = (State)api.GetState("http://serverpdvv.solucoesmaximas.com.br:8081/swagger", "http://serverpdvv.solucoesmaxima.com.br:8081/v1/GetVersion");

            Assert.That(stateTested.Version is string && !stateTested.IsOnline, "The version is not a string or the IsOnline is true");
        }

        [Test]
        public void GetVersionRight()
        {
            api.GetState("http://serverpdvv.solucoesmaxima.com.br:8081/swagger", "http://serverpdvv.solucoesmaxima.com.br:8081/v1/GetVersion");
            Assert.AreEqual(api.GetVersion(), "ServerPDV - MaxPedido.Api - 1.12.0.0");
        }

        [Test]
        public void GetVersionWrong()
        {
            api.GetState("http://serverpdvv.solucoesmaxima.com.br:8081/swagger", "http://serverpdvv.solucoesmaximas.com.br:8081/v1/GetVersion");

            Assert.AreEqual(api.GetVersion(), "Version not found. There is a problem in the endpoint");
        }
    }
}
