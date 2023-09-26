using DreamGallery.Domain.Entities;
using DreamGallery.Domain.Enums;

namespace DreamGallery.Service.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<AuthResult> AuthoriseAsync(Authentication auth);
    }
}
