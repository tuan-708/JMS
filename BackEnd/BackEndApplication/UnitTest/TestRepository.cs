using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;
using APIServer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Common;
using UnitTestCompany.Common;

namespace UnitTest
{
    [TestFixture]
    internal class TestRepository
    {
        List<JobDescription> listJ;
        private IJobRepository _jobRepository;
        Mock<JMSDBContext> context;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<JMSDBContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase") // Tạo database in-memory với tên "InMemoryDatabase"
            .Options;

            listJ = FakeData.fakeListJD();
            context = new Mock<JMSDBContext>(options);
            _jobRepository = new JobRepository(context.Object);
        }

        [Test]
        public void Test_Create_Should_Return_1()
        {
            //context.Setup(x => x.JobDescriptions)
            //    .ReturnsDbSet(FakeData.fakeListJD());
            var dbContext = FakeDI.CreateDbContext();
            var repo = new JobRepository(dbContext);
            var job = new JobDescription()
            {
                JobId = 0,
                RecuirterId = 2,
                Title = "Tên công việc ",
                GenderId = 1,
                AgeRequirement = "Yêu cầu tuổi",
                EducationRequirement = "Yêu cầu giáo dục",
                JobDetail = "Chi tiết công việc",
                ExperienceRequirement = "Yêu cầu kinh nghiệm",
                ProjectRequirement = "Yêu cầu dự án",
                SkillRequirement = "Yêu cầu kỹ năng",
                CertificateRequirement = "Yêu cầu chứng chỉ",
                OtherInformation = "Thông tin khác",
                CandidateBenefit = "Phúc lợi cho ứng viên",
                Salary = "Mức lương",
                ContactEmail = $"example@example.com",
                Address = "Địa chỉ công việc",
                CreatedAt = DateTime.Now,
                ExpiredDate = DateTime.Now.AddDays(30),
                IsDelete = false,
                CompanyId = 6,
            };
            var rs = repo.Create(job);
            Assert.AreEqual(rs, 1);
            Assert.AreEqual(dbContext.JobDescriptions.Count(), 1);
            dbContext.Dispose();
        }

        [Test]
        public void GetAllJob()
        {
            context.Setup(x => x.JobDescriptions)
                .ReturnsDbSet(FakeData.fakeListJD());
            var rs = _jobRepository.GetAll();
            Assert.IsNotNull(rs);
        }
    }
}
