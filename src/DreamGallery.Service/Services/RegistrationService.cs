using DreamGallery.Domain.Entities;
using DreamGallery.Service.Interfaces;

namespace DreamGallery.Service.Services
{
    internal class RegistrationService : IRegistrationService
    {
        public async Task<Registration> SignUpAsync(Registration registration)
        {
            Registration reg = new Registration()
            {
                Email = registration.Email,
                Password = registration.Password,
                CreatedAt = registration.CreatedAt,
            };
            return reg;
        }
    }
}
