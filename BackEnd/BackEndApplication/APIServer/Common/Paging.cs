using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace APIServer.Common
{
    public class Paging<T>
    {
        private readonly IConfiguration _configuration;

        public Paging(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public PagingResponseBody<List<T>> PagingObject(List<T> listData, int? page)
        {
            var k = listData.Count;
            if (k == 0)
            {
                return new PagingResponseBody<List<T>>
                {
                    message = GlobalStrings.SUCCESSFULLY,
                    statusCode = System.Net.HttpStatusCode.OK,
                };
            }
            var numberInOnePage = int.Parse(_configuration["PageSize"]);
            var totalPage = (int)Math.Ceiling((decimal)k / numberInOnePage);
            page = page <= 0 || page == null ? 1 : page;
            page = page > totalPage ? totalPage : page;
            var rs = listData.ToPagedList((int)page, numberInOnePage).ToList();
            return new PagingResponseBody<List<T>>
            {
                currentPage = (int)page,
                message = GlobalStrings.SUCCESSFULLY,
                data = rs,
                ObjectLength = k,
                statusCode = System.Net.HttpStatusCode.OK,
                TotalPage = totalPage,
            };
        }
    }
}
