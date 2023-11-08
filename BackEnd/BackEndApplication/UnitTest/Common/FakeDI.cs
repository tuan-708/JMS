using APIServer.MappingObj;
using APIServer.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestCompany.Common
{
    internal class FakeDI
    {
        public static IMapper FakeMapper(IMapper _mapper)
        {
            if (_mapper != null)
                return _mapper;

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapObject());
            });
             return mappingConfig.CreateMapper();
            //_mapper = mapper;
        }

        public static IConfiguration FakeConfiguration(IConfiguration configuration)
        {
            if(configuration != null)
                return configuration;
            var inMemorySettings = new Dictionary<string, string> {
    {"PageSize", "9"},
    {"SectionName:SomeKey", "SectionValue"},
};

            configuration = new ConfigurationBuilder()
               .AddInMemoryCollection(inMemorySettings)
               .Build();
            return configuration;
        }

        public static JMSDBContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<JMSDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString("N")).Options;
            var dbContext = new JMSDBContext(options);
            return dbContext;
        }
    }
}
