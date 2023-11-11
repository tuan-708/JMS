﻿using APIServer.DTO;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.Models.Entity;

namespace APIServer.IServices
{
    public interface IRecuirterService : IBaseService<Recuirter>
    {
        public Recuirter Login(string? username, string? password);
        public string generateToken(Recuirter? userInfo);
        public Recuirter getById(int? id);
        public int CreateRecuirterAccount(Recuirter? account);
        public List<CVMatching> GetCVAppliedHistory(int recruiterId, int? jobDescriptionId, DateTime? fromDate, DateTime? toDate);
        public PagingResponseBody<List<CVMatchingDTO>> GetCVPaging(int? page, List<CVMatchingDTO> listData);
        public CVMatching GetCVAppliedDetail(int recuiterId, int CVAppliedId);
        public Task<List<CVMatching>> GetCVFromMatchingJD(int recruiterId, int jobDescriptionId, int numberRequirement);
        public string getEstimateDate(int jobId, DateTime dateRequirment);
        public List<CVMatching> GetCVSelected(int recruiterId, int jobDescriptionId);
        public List<CVMatching> GetCVMatched(int recruiterId, int jobDescriptionId);

    }
}
