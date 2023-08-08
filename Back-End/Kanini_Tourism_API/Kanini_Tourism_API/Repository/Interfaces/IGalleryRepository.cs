using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Tourism_API.Models;

namespace Kanini_Tourism_API.Repositories
{
    public interface IGalleryRepository
    {
        IEnumerable<Gallery> GetAllImages();
        Task<Gallery> ImageUpload(IFormFile imageFile);
    }
}
