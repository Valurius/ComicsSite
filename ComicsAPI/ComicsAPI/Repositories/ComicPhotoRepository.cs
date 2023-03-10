using ComicsAPI.Data;
using ComicsAPI.Models;
using ComicsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComicsAPI.Repositories
{
    public class ComicPhotoRepository : IBase<ComicPhotos>
    {
        private readonly AppDbContext _db;

        public ComicPhotoRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Add(ComicPhotos item)
        {
            try
            {
                await _db.ComicsPhotos.AddAsync(item);
                await _db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ComicPhotos>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ComicPhotos> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async void Save()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Update(ComicPhotos item)
        {
            var comicPhotos = await _db.ComicsPhotos.FirstOrDefaultAsync(x => x.Id == item.Id);

            if (comicPhotos == null) { return false; }

            _db.ChangeTracker.Clear();

            try
            {
                _db.Entry(comicPhotos).State = EntityState.Modified;

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
