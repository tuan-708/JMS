using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Repositories
{
    public class SliderRepository : IBaseRepository<Slider>
    {
        private readonly JMSDBContext context;

        public SliderRepository(JMSDBContext context)
        {
            this.context = context;
        }

        public int Create(Slider data)
        {
            context.Sliders.AddAsync(data);
            return context.SaveChangesAsync().Result;
        }

        public int CreateById(Slider data, int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            var data = context.Sliders.FirstAsync(x => x.Id == id).Result;
            context.Sliders.Remove(data);
            return context.SaveChangesAsync().Result;
        }

        public List<Slider> GetAll()
        {
            return context.Sliders
                .OrderBy(x => x.Order)
                .ToListAsync().Result;
        }

        public List<Slider> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public Slider GetById(int id)
        {
            return context.Sliders.FirstOrDefaultAsync(x => x.Id == id).Result;
        }

        public int Update(Slider data)
        {
            context.Sliders.Update(data);
            return context.SaveChangesAsync().Result;
        }
    }
}
