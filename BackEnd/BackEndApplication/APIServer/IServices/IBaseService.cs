namespace APIServer.IServices
{
    public interface IBaseService<T>
    {
        public List<T> getAll();
        public List<T> getAllById(int id);
        public int Update(T data);
        public int Delete(T data);
        public int Create(T data);
        Task<string> GetResult(string prompt);
    }
}
