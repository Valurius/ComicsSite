using ComicsAPI.Models;
using ComicsAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComicsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly IComic _comicsRepository;

        public ComicsController(IComic comicsRepository)
        {
            _comicsRepository = comicsRepository;
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

            if (comic.Result == false) { return Results.NotFound(comic.Message); }

            return Results.Ok(comic.Value);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IResult> Post(Comic comic)
        {
            var result = await _comicsRepository.Add(comic);

            return result.Result ?  Results.Ok(result.Message) : Results.BadRequest(result.Message);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IResult> Delete(int id)
        {
            var result = await _comicsRepository.DeleteById(id);

            return result.Result ? Results.Ok(result.Message) : Results.BadRequest(result.Message);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IResult> Put(Comic comic)
        {
            var result = await _comicsRepository.Update(comic);

            return result.Result ? Results.Ok(result.Message) : Results.BadRequest(result.Message);
        }
    }
}
