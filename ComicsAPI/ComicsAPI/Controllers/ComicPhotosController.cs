using ComicsAPI.Models;
using ComicsAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ComicsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicPhotosController : ControllerBase
    {
        private readonly IComicPhoto _comicPhotoRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ComicPhotosController(IComicPhoto comicPhotoRepository, IWebHostEnvironment webHostEnvironment)
        {
            _comicPhotoRepository = comicPhotoRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        [Route("savePhoto")]
        public async Task<IResult> SavePhoto()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFiles = httpRequest.Files;

                foreach (var file in postedFiles)
                {
                    var phisicalPath = _webHostEnvironment.ContentRootPath + "/Images/" + file.FileName;

                    using (var stream = new FileStream(phisicalPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                return Results.Ok("Изображение успешно загружено");
            }
            catch (Exception)
            {
                return Results.BadRequest("Не удалось загрузить изображение.");
            }
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
