using FleetManager.Desktop.Data;
using FleetManager.Desktop.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;

namespace FleetManager.Desktop.DataTests
{
    [TestClass]
    public class DaoFactoryTests
    {
        [TestMethod]
        public void CreateCarDaoForMemoryDataContextTest()
        {
            IDataContext dataContext = new TestDataContext();

            IDao<Car> carDao = DaoFactory.Create<Car>(dataContext);

            Assert.IsNotNull(carDao);
        }

        [TestMethod]
        public void CreateLocationDaoForMemoryDataContextTest()
        {
            IDataContext dataContext = new TestDataContext(); 

            IDao<Location> locationDao = DaoFactory.Create<Location>(dataContext);

            Assert.IsNotNull(locationDao);
        }

        [TestMethod]
        public void CreateUnknownDaoForMemoryDataContextTest()
        {
            IDataContext dataContext = new TestDataContext(); 

            Exception ex = Assert.ThrowsException<DaoFactoryException>(() => DaoFactory.Create<UnknownModel>(dataContext));
            Assert.AreEqual($"Model [{typeof(UnknownModel).Name}] not supported", ex.Message);
        }

        [TestMethod]
        public void CreateCarDaoForRESTDataContextTest()
        {
            // TODO: test that a IDao<Car> implementation for REST is returned from the factory (solve exercise )
            IDataContext dataContext = new TestDataContext();

            IDao<Location> locationDao = DaoFactory.Create<Location>(dataContext);

            Assert.IsNotNull(locationDao);
        }

        [TestMethod]
        public void CreateLocationDaoForRESTDataContextTest()
        {
            // TODO: test that a IDao<Location> implementation for REST is returned from the factory (solve exercise )

            Assert.Inconclusive();
        }

        [TestMethod]
        public void CreateUnknownDaoForRestDataContextTest()
        {
            // TODO: test that a DaoFactoryException is thrown from the factory (solve exercise )

            Assert.Inconclusive();
        }

        private class UnknownModel
        {
            // Used for testing unknown dao types
        }
    }
}
