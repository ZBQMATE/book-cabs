using CabBooking.Core.Entities;
using CabBooking.Core.RepositoryInterfaces;
using CabBooking.Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CabBooking.UnitTest
{
    [TestClass]
    public class CabTypeServiceUnitTest
    {
        private CabTypeService _sut;
        private static List<CabType> _cars;
        private Mock<IAsyncRepository<CabType>> _mockCabTypeRepository;
        [TestInitialize]

        public void OneTimeSetup()
        {
            _mockCabTypeRepository = new Mock<IAsyncRepository<CabType>>();
            _sut = new CabTypeService(_mockCabTypeRepository.Object);
            _mockCabTypeRepository.Setup(m => m.ListAllAsync()).ReturnsAsync(_cars);
        }

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _cars = new List<CabType>
            {
                new CabType {Id = 1, Name = "Mazda a"},
                new CabType {Id = 2, Name = "Mazda 100"},
                new CabType {Id = 100, Name = "GM Banana"},
                new CabType {Id = 4, Name = "Tope CCC"},
                new CabType {Id = 5, Name = ""},
                new CabType {Id = 7, Name = "Kumiko 888"}
                
            };
        }

        [TestMethod]
        public async Task TestGetCabTypeListFromFakeData()
        {
            var cars = await _sut.GetAllCabTypes();
            Assert.IsNotNull(cars);
            Assert.IsInstanceOfType(cars, typeof(IEnumerable<CabType>));
        }
    }
}
