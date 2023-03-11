using ComicsAPI.Data;
using ComicsAPI.Models;
using ComicsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComicsAPI.Repositories
{
    public class ComicRepository : IComic
    {
        private readonly AppDbContext _db;

        public ComicRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Response> Add(Comic comic)
        {
            try
            {
                await _db.Comics.AddAsync(comic);
                await _db.SaveChangesAsync();

                return new Response("Комикс успешно добавлен",true);
            }
            catch (Exception ex) 
            {
                return new Response(ex.Message, false);
            }
        }

        public async Task<Response> DeleteById(int id)
        {
            var comic = await _db.Comics.FirstOrDefaultAsync(x => x.ComicId == id);

            if (comic == null) { return new Response("Комикс не найден", false); };

            try
            {
                _db.Remove(comic);
                await _db.SaveChangesAsync();

                return new Response("Комикс успешно удален", true);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, false);
            }
        }

        public async Task<List<Comic>> GetAll()
        {
            return await _db.Comics.Include(x => x.ComicPhotos).ToListAsync();
        }

        public async Task<Response> GetById(int id)
        {
            var comic = await _db.Comics.Include(x => x.ComicPhotos).FirstOrDefaultAsync(x => x.ComicId == id);

            if(comic == null) { return new Response("Комикс не найден", false); };

            return new Response("Комикс найден", true, comic);
        }

        public async void Save()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<Response> Update(Comic oldComics)
        {
            var comic = await _db.Comics.FirstOrDefaultAsync(x => x.ComicId == oldComics.ComicId);

            if (comic == null) { return new Response("Комикс не найден", false); }

            _db.ChangeTracker.Clear();

            try
            {
               _db.Entry(oldComics).State = EntityState.Modified;

                await _db.SaveChangesAsync();

                return new Response("Комикс успешно обновлен", true); ;
            }
            catch (Exception ex) 
            {
                return new Response(ex.Message, false); ;
            }
        }
    }
}
