namespace APIServer.IRepositories
{
    public interface IBaseRepository<T>
    {
        public List<T> GetAll();
        public List<T> GetAllById(int id);
        public T GetById(int id);
        public int Create(T data);
        public int CreateById(T data, int id);
        public int Update(T data);
        public int Delete(int id);
    }
}
