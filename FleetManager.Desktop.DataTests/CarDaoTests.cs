using FleetManager.Desktop.Data;
using FleetManager.Desktop.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace FleetManager.Desktop.DataTests
{
    [TestClass]
    public class CarDaoTests
    {
        private IDataContext _dataContext;

        [TestInitialize]
        public void Initialize()
        {
            // TODO: (Step 5) You should change this to instantiate another datacontext
            // to test integration with other datasources, but DO NOT change the
            // tests!
            _dataContext = RestDataContext.Instance;
        }

        [TestMethod]
        public void ReadAllCarsTest()
        {
            IDao<Car> dao = DaoFactory.Create<Car>(_dataContext);

            IEnumerable<Car> test = dao.Read();

            Assert.IsNotNull(test);
            //Assert.AreEqual(6, test.Count());
        }

        [TestMethod]
        public void ReadCarByIdTest()
        {
            IDao<Car> dao = DaoFactory.Create<Car>(_dataContext);

            IEnumerable<Car> test = dao.Read(c => c.Id == 1);

            Assert.IsNotNull(test);
            Assert.AreEqual(1, test.Count());
            Assert.AreEqual("Ford", test.Single().Brand);
        }

        [TestMethod]
        public void ReadByNonExistingIdTest()
        {
            //  Arrange
            IDao<Car> dao = DaoFactory.Create<Car>(_dataContext);

            // Act
            IEnumerable<Car> test = dao.Read(c => c.Id == 11);

            // Assert
            Assert.IsNotNull(test);
            Assert.AreEqual(0, test.Count());
        }

        [TestMethod]
        public void CreateCarTest()
        {
            //  Arrange
            IDao<Car> dao = DaoFactory.Create<Car>(_dataContext);
            Car car = new() { Brand = "Hyundai", Mileage = 32000 };

            // Act
            Car test = dao.Create(car);

            // Assert
            Assert.IsNotNull(test);
            Assert.AreEqual(17, test.Id);
        }

        [TestMethod]
        public void UpdateCarTest()
        {
            //  Arrange
            IDao<Car> dao = DaoFactory.Create<Car>(_dataContext);
            Car car = new() { Id = 1, Brand = "Ford", Mileage = 45000 };

            // Act
            bool test = dao.Update(car);

            // Assert
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void UpdateNonExistingCarTest()
        {
            //  Arrange
            IDao<Car> dao = DaoFactory.Create<Car>(_dataContext);
            Car car = new() { Id = 22, Brand = "Ford", Mileage = 45000 };

            // Act
            bool test = dao.Update(car);

            // Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void DeleteCarTest()
        {
            //  Arrange
            IDao<Car> dao = DaoFactory.Create<Car>(_dataContext);
            Car car = new() { Id = 2 };

            // Act
            bool test = dao.Delete(car);

            // Assert
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void DeleteNonExistingCarTest()
        {
            //  Arrange
            IDao<Car> dao = DaoFactory.Create<Car>(_dataContext);
            Car car = new() { Id = 22 };

            // Act
            bool test = dao.Delete(car);

            // Assert
            Assert.IsFalse(test);
        }
    }
}
