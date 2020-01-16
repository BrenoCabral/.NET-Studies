using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Monitoring_App.Domain.Services.Types;
using Monitoring_App.Domain.States;

namespace MonitoringTest.Services
{
    
    class AngularTest
    {
        Angular angular = new Angular();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsOnlineTrue()
        {
            angular.GetState("http://10.163.17.219:4400/#/login","");
            
            Assert.IsTrue(angular.IsOnline());
        }
        [Test]
        public void IsOnlineFalse()
        {
            angular.GetState("http://10.163.17.219:4401/#/login","");

            Assert.IsFalse(angular.IsOnline());
        }
        [Test]
        public void ReturnStateOnline()
        {
            State stateTested = (State)angular.GetState("https://www.google.com","");

            Assert.That(stateTested.Version is string && stateTested.IsOnline, "The version is not a string or the IsOnline is false");
        }
        [Test]
        public void ReturnStateFalse()
        {
            State stateTested = (State)angular.GetState("http://10.163.17.219:4401/#/login","");

            Assert.That(stateTested.Version is string && !stateTested.IsOnline, "The version is not a string or the IsOnline is true");
        }

    }
}
