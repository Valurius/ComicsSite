using ComicsAPI.Models;

namespace ComicsAPI.Repositories.Interfaces
{
    public interface IComicPhoto
    {
        public Task<Response> Add(ComicPhoto photo);
        public Task<Response> Update(ComicPhoto photo);
        public Task<Response> DeleteById(int id);
    }
}
