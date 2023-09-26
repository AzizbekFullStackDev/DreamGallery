using DreamGallery.Domain.Commons;

namespace DreamGallery.Domain.Entities
{
    public class Registration : Auditable
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
