using DreamGallery.Domain.Entities;

namespace DreamGallery.Service.Interfaces
{
    public interface IRegistrationService
    {
        public Task<Registration> SignUpAsync(Registration registration);
    }
}
