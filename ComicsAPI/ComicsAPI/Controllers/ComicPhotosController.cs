using ComicsAPI.Models;
using ComicsAPI.Repositories;
using ComicsAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComicsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicPhotosController : ControllerBase
    {
        private readonly IComicPhoto _comicPhotoRepository;

        public ComicPhotosController(IComicPhoto comicPhotoRepository)
        {
            _comicPhotoRepository = comicPhotoRepository;
        }

        [HttpPost]
        [Route("addPhoto")]
        public async Task<IResult> Post(ComicPhoto comicPhoto)
        {
            var result = await _comicPhotoRepository.Add(comicPhoto);

            return result.Result ? Results.Ok(result.Message) : Results.BadRequest(result.Message);
        }

        [HttpPut]
        [Route("updatePhoto")]
        public async Task<IResult> Put(ComicPhoto comicPhoto)
        {
            var result = await _comicPhotoRepository.Update(comicPhoto);

            return result.Result ? Results.Ok(result.Message) : Results.BadRequest(result.Message);
        }

        [HttpDelete]
        [Route("deletePhoto")]
        public async Task<IResult> Delete(int id)
        {
            var result = await _comicPhotoRepository.DeleteById(id);

            return result.Result ? Results.Ok(result.Message) : Results.BadRequest(result.Message);
        }
    }
}
