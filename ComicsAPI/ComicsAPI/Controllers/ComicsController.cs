using ComicsAPI.Models;
using ComicsAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComicsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly IBase<Comic> _comicsRepository;
        private readonly IBase<ComicPhotos> _comicsPhotosRepository;

        public ComicsController(IBase<Comic> comicsRepository, IBase<ComicPhotos> comicsPhotosRepository)
        {
            _comicsRepository = comicsRepository;
            _comicsPhotosRepository = comicsPhotosRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IResult> Get()
        {
            var comics = await _comicsRepository.GetAll();

            return Results.Ok(comics);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IResult> Get(int id)
        {
            var comic = await _comicsRepository.GetById(id);

            if (comic == null) { return Results.NotFound("Комикс не найден"); }

            return Results.Ok(comic);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IResult> Post(Comic comic)
        {
            var result = await _comicsRepository.Add(comic);

            return result ?  Results.Ok("Комикс успешно добавлен") : Results.BadRequest("Произошла ошибка при добавлении комикса");
        }

        [HttpPost]
        [Route("addPhotos")]
        public async Task<IResult> Post(ComicPhotos comicPhotos)
        {
            var result = await _comicsPhotosRepository.Add(comicPhotos);

            return result ? Results.Ok("Фото комикса успешно добавлены") : Results.BadRequest("Произошла ошибка при добавлении фото комикса");
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IResult> Delete(int id)
        {
            var result = await _comicsRepository.DeleteById(id);

            return result ? Results.Ok("Комикс успешно удален") : Results.BadRequest("Произошла ошибка при удалении комикса");
        }

        [HttpPut]
        [Route("update")]
        public async Task<IResult> Put(Comic comic)
        {
            var result = await _comicsRepository.Update(comic);

            return result ? Results.Ok("Комикс успешно обновлен") : Results.BadRequest("Произошла ошибка при обновлении комикса");
        }
    }
}
