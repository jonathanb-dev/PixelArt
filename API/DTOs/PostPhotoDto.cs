using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class PostPhotoDto
    {
        public string Url { get; set; }
        [Required]
        public IFormFile File { get; set; }
        public string PublicId { get; set; }
    }
}