﻿using APIServer.Common;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models;
using APIServer.Models.Entity;

namespace APIServer.Services
{
    public class CurriculumVitaeService : ICurriculumVitaeService
    {
        private readonly IBaseRepository<CurriculumVitae> _context;

        public CurriculumVitaeService(IBaseRepository<CurriculumVitae> context)
        {
            _context = context;
        }

        public int Create(CurriculumVitae data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(CurriculumVitae data, int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(CurriculumVitae data)
        {
            throw new NotImplementedException();
        }

        public List<CurriculumVitae> getAll()
        {
            return _context.GetAll();
        }

        public List<CurriculumVitae> getAllById(int id)
        {
            throw new NotImplementedException();
        }

        public CurriculumVitae? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CurriculumVitae GetCurriculumVitae(int id)
        {
            return _context.GetById(id);
        }

        public string GetResult(string prompt, IConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public int Update(CurriculumVitae data)
        {
            throw new NotImplementedException();
        }

        
    }
}
