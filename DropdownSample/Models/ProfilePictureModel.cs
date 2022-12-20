using System.ComponentModel.DataAnnotations;

namespace DropdownSample.Models
{
    public class ProfilePictureModel
    {
        [Required]
        public IFormFile NewPicture { get; set; }
    }
}
