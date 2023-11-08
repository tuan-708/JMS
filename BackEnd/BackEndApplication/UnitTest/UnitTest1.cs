using AutoMapper;
using Microsoft.Extensions.Configuration;
using Moq;
using UnitTestCompany.Common;

namespace UnitTestCompany
{
    public class Tests
    {
        private IMapper mapper;
        private IConfiguration configuration;

        [SetUp]
        public void Setup()
        {
            mapper = FakeDI.FakeMapper(mapper);
            //var mockConfiguration = new Mock<IConfiguration>();
            configuration = FakeDI.FakeConfiguration(configuration);
        }

        [Test]
        public void TestMapper()
        {
            //mapper = FakeDI.FakeMapper(mapper);
            if (mapper != null)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void TestGetConfigurationPage()
        {
            if (configuration == null) Assert.Fail();
            var rs = configuration["PageSize"];
            Assert.AreEqual("9", rs);
        }
    }
}