using DreamGallery.Domain.Entities;
using DreamGallery.Service.Interfaces;

namespace DreamGallery.Service.Services
{
    public class RegistrationService : IRegistrationService
    {
        public async Task<Registration> SignUpAsync(Registration registration)
        {
            Registration reg = new Registration()
            {
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                PhoneNumber = registration.PhoneNumber,
                Email = registration.Email,
                Password = registration.Password,
                CreatedAt = registration.CreatedAt,
            };
            return reg;
        }
    }
}
