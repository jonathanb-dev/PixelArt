using DL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL.Services
{
    public interface IPhotoService
    {
        Task<Photo> GetPhoto(int id);
        Task<IEnumerable<Photo>> GetPhotos();
        Task AddPhoto(Photo photo);
    }
}