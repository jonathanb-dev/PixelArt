using DL.Entities;
using System.Threading.Tasks;

namespace DL.Services
{
    public interface IPhotoService
    {
        Task<Photo> GetPhoto(int id);
        Task AddPhoto(Photo photo);
    }
}