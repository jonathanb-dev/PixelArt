using API.DTOs;
using AutoMapper;
using DL.Entities;

namespace API.AutoMapperProfiles
{
    public class PhotoProfile : Profile
    {
        public PhotoProfile()
        {
            // Entity to DTO
            CreateMap<Photo, PhotoDto>();
            CreateMap<Photo, PostPhotoDto>();
            // DTO to Entity
            CreateMap<PhotoDto, Photo>();
            CreateMap<PostPhotoDto, Photo>();
        }
    }
}