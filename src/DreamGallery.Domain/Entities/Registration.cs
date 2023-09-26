using DreamGallery.Domain.Commons;

namespace DreamGallery.Domain.Entities
{
    public class Registration : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
