namespace APIServer.IRepositories
{
    public interface IBaseListRepository<T>
    {
        public List<T> GetAll();
        public List<T> GetAll(int id);
        public int CreateList(List<T> data, int id);
        public int UpdateList(List<T> data, int id);
        public int DeleteList(List<T> data, int id);
    }
}
