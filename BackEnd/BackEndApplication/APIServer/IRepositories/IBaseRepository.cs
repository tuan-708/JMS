namespace APIServer.IRepositories
{
    public interface IBaseRepository<T>
    {
        public List<T> GetAll();
        public T GetById(int id);
        public int Create(T data);
        public int Update(T data);
        public int Delete(int id);
    }
}
