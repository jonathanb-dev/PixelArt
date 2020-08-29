using API.DTOs;
using API.Helpers;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DL.Entities;
using DL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfiguration;
        private Cloudinary _cloudinary;

        public PhotosController(
            IMapper mapper,
            IPhotoService photoService,
            IOptions<CloudinarySettings> cloudinaryConfiguration)
        {
            _mapper = mapper;
            _photoService = photoService;
            _cloudinaryConfiguration = cloudinaryConfiguration;

            Account account = new Account(
                _cloudinaryConfiguration.Value.CloudName,
                _cloudinaryConfiguration.Value.ApiKey,
                _cloudinaryConfiguration.Value.ApiSecret);

            _cloudinary = new Cloudinary(account);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            Photo photo = await _photoService.GetPhoto(id);

            PhotoDto photoDto = _mapper.Map<PhotoDto>(photo);

            return Ok(photoDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostPhoto([FromForm]PostPhotoDto postPhotoDto)
        {
            IFormFile file = postPhotoDto.File;

            ImageUploadResult uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (Stream stream = file.OpenReadStream())
                {
                    ImageUploadParams uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            postPhotoDto.Url = uploadResult.Url.ToString();
            postPhotoDto.PublicId = uploadResult.PublicId;

            Photo photo = _mapper.Map<Photo>(postPhotoDto);

            await _photoService.AddPhoto(photo);

            return CreatedAtAction(nameof(GetPhoto), new { id = photo.Id }, _mapper.Map<PhotoDto>(photo));
        }
    }
}