using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class PostPhotoDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        [Required]
        public IFormFile File { get; set; }
        public string PublicId { get; set; }
    }
}