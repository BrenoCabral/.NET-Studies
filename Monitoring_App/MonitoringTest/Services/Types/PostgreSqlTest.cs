using Monitoring_App.Domain.Services.Types;
using Monitoring_App.Domain.States;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringTest.Services
{
    class PostgreSqlTest
    {
        PostgreSQL postgreSQL = new PostgreSQL();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsOnlineTrue()
        {
            postgreSQL.GetState("Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=asd123;", "");

            Assert.IsTrue(postgreSQL.IsOnline());
        }
        [Test]
        public void IsOnlineFalse()
        {
            postgreSQL.GetState("Server=127.0.0.1;Port=5432;Database=postgress;User Id=postgres;Password=asd123;", "");

            Assert.IsFalse(postgreSQL.IsOnline());
        }
        [Test]
        public void GetStateOnline()
        {
            State stateTested = (State)postgreSQL.GetState("Server=127.0.0.2;Port=5432;Database=postgres;User Id=postgres;Password=asd123;", "");

            Assert.That(stateTested.Version is string && stateTested.IsOnline, "The version is not a string or the IsOnline is false");
        }
        [Test]
        public void GetStateOffline()
        {
            State stateTested = (State)postgreSQL.GetState("Server=127.0.0.1;Port=5432;Database=postgress;User Id=postgres;Password=asd123;", "");

            Assert.That(stateTested.Version is string && !stateTested.IsOnline, "The version is not a string or the IsOnline is true");
        }

        [Test]
        public void GetVersionRight()
        {
            postgreSQL.GetState("Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=asd123;", "");
            Assert.AreEqual("PostgreSQL 12.1, compiled by Visual C++ build 1914, 64-bit", postgreSQL.GetVersion());
        }

        [Test]
        public void GetVersionWrong()
        {
            postgreSQL.GetState("Server=127.0.0.1;Port=5432;Database=postgress;User Id=postgres;Password=asd123;", "");

            Assert.AreEqual("Version not found.", postgreSQL.GetVersion());
        }
    }
}
