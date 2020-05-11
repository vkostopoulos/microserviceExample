using AutoMapper;
using BOL;
using CustomerService.Controllers;
using CustomerService.Helpers;
using DAL.Repository;
using DTO;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerService.Tests.Controllers
{
    [TestFixture]
    public class CustomerControllerTests
    {

        [SetUp]
        public void SetUp()
        {
        }


        [Test]
        public async Task GetAsync()
        {
            IList<Customer> customersTest = new List<Customer>
            {
                new Customer()
                {
                    Id = 1,
                    Name = "test user 1",
                    Address = "test address 1",
                    Contact = "6973937771"
                },
                    new Customer()
                {
                    Id = 2,
                    Name = "test user 2",
                    Address = "test address 2",
                    Contact = "6973937771"
                }
            };

            var mockRepo = new Mock<IRepository<Customer>>();
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(customersTest);


            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var expected = mapper.Map<IEnumerable<Customer>, IEnumerable<customerDto>>(customersTest);

            var controller = new CustomerController(mapper, mockRepo.Object);

            var result = await controller.GetAsync();
            Assert.IsAssignableFrom<IEnumerable<customerDto>>(result);
            CollectionAssert.AreEqual(result, expected);
        }
    }
}
