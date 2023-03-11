using ComicsAPI.Data;
using ComicsAPI.Models;
using ComicsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComicsAPI.Repositories
{
    public class ComicPhotoRepository : IComicPhoto
    {
        private readonly AppDbContext _db;

        public ComicPhotoRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Response> Add(ComicPhoto photo)
        {
            try
            {
                await _db.ComicsPhotos.AddAsync(photo);
                await _db.SaveChangesAsync();

                return new Response("Фото комикса успешно добавлено", true);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, false);
            }
        }

        public async Task<Response> DeleteById(int id)
        {
            var comicPhoto = await _db.ComicsPhotos.FirstOrDefaultAsync(x => x.Id == id);

            if (comicPhoto == null) { return new Response("Фото комикса не найдено", false); };

            try
            {
                _db.Remove(comicPhoto);
                await _db.SaveChangesAsync();

                return new Response("Фото комикса успешно удалено", true);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, false);
            }
        }

        public async Task<Response> Update(ComicPhoto oldPhoto)
        {
            var comicPhoto = await _db.ComicsPhotos.FirstOrDefaultAsync(x => x.Id == oldPhoto.Id);

            if (comicPhoto == null) { return new Response("Фото комикса не найдено", false); }

            _db.ChangeTracker.Clear();

            try
            {
                _db.Entry(oldPhoto).State = EntityState.Modified;

                await _db.SaveChangesAsync();

                return new Response("Фото комикса успешно обновлено", true); ;
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, false); ;
            }
        }
    }
}
