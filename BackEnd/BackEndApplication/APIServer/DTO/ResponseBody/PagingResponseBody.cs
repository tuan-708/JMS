namespace APIServer.DTO.ResponseBody
{
    public class PagingResponseBody<T> : BaseResponseBody<T> 
    {
        public int ObjectLength { get; set; }
        public int TotalPage { get; set; }
        public int currentPage {  get; set; }
    }
}
