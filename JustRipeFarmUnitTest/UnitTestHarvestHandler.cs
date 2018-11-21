using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using JustRipe_Farm;

namespace JustRipeFarmUnitTest
{
    [TestClass]
    public class UnitTestHarvestHandler
    {
        [TestMethod]
        public void TestAddNewHarvest()
        {
            DbConnector dbC = new DbConnector();
            string resp = dbC.connect();
            Assert.AreSame("Done", resp);

            Harvest harvest = new Harvest();
            harvest.CropsType = "tomato";
            harvest.HarvestTime = new DateTime(2018, 12, 17, 16, 0, 0);
            harvest.HarvestMethod = " clearcutting";

            HarvestHandler labrHand = new HarvestHandler();
            int resp2 = labrHand.addNewHarvest(dbC.getConn(), harvest);
            Assert.AreNotSame("Done", resp2);
        }
    }
}
