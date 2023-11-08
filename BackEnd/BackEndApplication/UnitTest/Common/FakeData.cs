using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Common
{
    internal class FakeData
    {
        public static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }

        public static List<JobDescription> fakeListJD()
        {
            var list = new List<JobDescription>();

            Company company = new Company
            {
                CompanyName = "Tên công ty",
            };
            for (int i = 1; i < 4; i++)
            {
                var job = new JobDescription
                {
                    JobId = i,
                    RecuirterId = 2,
                    Title = "Tên công việc " + i,
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
                    ContactEmail = $"example{i}@example.com",
                    Address = "Địa chỉ công việc",
                    CreatedAt = DateTime.Now,
                    ExpiredDate = DateTime.Now.AddDays(30),
                    IsDelete = false,
                    CompanyId = 6,
                };
                list.Add(job);
            }
            return list;
        }
    }
}
