using Monitoring_App.Domain.Services.Types;
using Monitoring_App.Domain.States;
using NUnit.Framework;

namespace MonitoringTest.Services
{
    class OracleTest
    {
        OracleService oracle = new OracleService();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsOnlineTrue()
        {
            oracle.GetState("User ID=STO_424_PRODUCAO; Password=mxma#maxpedidonuvem; Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=maxsolucoes-xios.cm35ayc6yrqh.us-east-1.rds.amazonaws.com)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME = XIOS)))", "");

            Assert.IsTrue(oracle.IsOnline());
        }
        [Test]
        public void IsOnlineFalse()
        {
            oracle.GetState("User ID=STO_424_PRODUCAO; Password=mxma#maxpedidonuvem; Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=maxsolucoess-xios.cm35ayc6yrqh.us-east-1.rds.amazonaws.com)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME = XIOS)))", "");

            Assert.IsFalse(oracle.IsOnline());
        }
        [Test]
        public void GetStateOnline()
        {
            State stateTested = (State)oracle.GetState("User ID=STO_424_PRODUCAO; Password=mxma#maxpedidonuvem; Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=maxsolucoes-xios.cm35ayc6yrqh.us-east-1.rds.amazonaws.com)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME = XIOS)))", "");

            Assert.That(stateTested.Version is string && stateTested.IsOnline, "The version is not a string or the IsOnline is false");
        }
        [Test]
        public void GetStateOffline()
        {
            State stateTested = (State)oracle.GetState("User ID=STO_424_PRODUCAO; Password=mxma#maxpedidonuvem; Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=maxsolucoess-xios.cm35ayc6yrqh.us-east-1.rds.amazonaws.com)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME = XIOS)))", "");

            Assert.That(stateTested.Version is string && !stateTested.IsOnline, "The version is not a string or the IsOnline is true");
        }

        [Test]
        public void GetVersionRight()
        {
            oracle.GetState("User ID=STO_424_PRODUCAO; Password=mxma#maxpedidonuvem; Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=maxsolucoes-xios.cm35ayc6yrqh.us-east-1.rds.amazonaws.com)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME = XIOS)))", "");
            Assert.AreEqual("12.2.0.1.0", oracle.GetVersion());
        }

        [Test]
        public void GetVersionWrong()
        {
            oracle.GetState("User ID=STO_424_PRODUCAO; Password=mxma#maxpedidonuvem; Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=maxsolucoess-xios.cm35ayc6yrqh.us-east-1.rds.amazonaws.com)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME = XIOS)))", "");

            Assert.AreEqual("Version not found.", oracle.GetVersion());
        }
    }
}
