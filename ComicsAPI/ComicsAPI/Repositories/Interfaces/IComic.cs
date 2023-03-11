using ComicsAPI.Models;

namespace ComicsAPI.Repositories.Interfaces
{
    public interface IComic
    {
        public Task<List<Comic>> GetAll();    
        public Task<Response> GetById(int id);    
        public Task<Response> Update(Comic comic);    
        public Task<Response> DeleteById(int id);    
        public Task<Response> Add(Comic comic);
        public void Save();
    }
}
