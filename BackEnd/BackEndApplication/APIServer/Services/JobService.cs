using APIServer.Common;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;

namespace APIServer.Services
{
    public class JobService : IJobService
    {
        private readonly IBaseRepository<JobPost> context;

        public JobService(IBaseRepository<JobPost> context)
        {
            this.context = context;
        }

        public int Create(JobPost data)
        {
            if(Validation.checkStringIsEmpty(
                data.EmailConnect, data.JobDescription, data.JobRequirement,
                data.JobType, data.Title, data.Address, data.SalaryMin
                ))
            {
                throw new MissingFieldException("job not completed yet");
            }
            data.IsDelete = false;
            data.status = StatusJob.Finding;
            data.CreatedAt = DateTime.Now;
            data.ExipredDate = DateTime.Now.AddDays(7);
            return context.Create(data);
        }

        public int Delete(JobPost data)
        {
            throw new NotImplementedException();
        }

        public List<JobPost> getAll()
        {
            var rs = context.GetAll();
            return rs;
        }

        public int Update(JobPost data)
        {
            throw new NotImplementedException();
        }
    }
}
