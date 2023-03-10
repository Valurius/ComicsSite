using ComicsAPI.Data;
using ComicsAPI.Models;
using ComicsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComicsAPI.Repositories
{
    public class ComicsRepository : IBase<Comic>
    {
        private readonly AppDbContext _db;

        public ComicsRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Add(Comic comic)
        {
            try
            {
                await _db.Comics.AddAsync(comic);
                await _db.SaveChangesAsync();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> DeleteById(int id)
        {
            var comic = await _db.Comics.FirstOrDefaultAsync(x => x.ComicId == id);

            if (comic == null) { return false; };

            try
            {
                _db.Remove(comic);
                await _db.SaveChangesAsync();

                return true;
            }
            catch 
            { 
                return false;
            }
        }

        public async Task<List<Comic>> GetAll()
        {
            return await _db.Comics.Include(x => x.ComicPhotos).ToListAsync();
        }

        public async Task<Comic> GetById(int id)
        {
            var comic = await _db.Comics.Include(x => x.ComicPhotos).FirstOrDefaultAsync(x => x.ComicId == id);

            if(comic == null) { return comic; };// exeption

            return comic;
        }

        public async void Save()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Update(Comic oldComics)
        {
            var comic = await _db.Comics.FirstOrDefaultAsync(x => x.ComicId == oldComics.ComicId);

            if (comic == null) { return false; }

            _db.ChangeTracker.Clear();

            try
            {
               _db.Entry(oldComics).State = EntityState.Modified;

                await _db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
