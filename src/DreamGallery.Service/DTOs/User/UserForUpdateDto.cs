using DreamGallery.Domain.Enums;

namespace DreamGallery.Service.DTOs.User
{
    public class UserForUpdateDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public string PhoneNumber { get; set; }

        public Method PaymentMethod { get; set; }
        public Roles Role { get; set; }

    }
}
