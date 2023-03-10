namespace ComicsAPI.Repositories.Interfaces
{
    public interface IBase<T> where T : class
    {
        public Task<List<T>> GetAll();    
        public Task<T> GetById(int id);    
        public Task<bool> Update(T item);    
        public Task<bool> DeleteById(int id);    
        public Task<bool> Add(T item);
        public void Save();
    }
}
