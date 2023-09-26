using DreamGallery.Domain.Entities;
using DreamGallery.Domain.Enums;
using DreamGallery.Service.Interfaces;

namespace DreamGallery.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<AuthResult> AuthoriseAsync(Authentication auth)
        {
            UserService ServiceForUser = new UserService();
            ArtistService ServiceForArtist = new ArtistService();
            
            var GetAllUsers = await ServiceForUser.GetAllAsync();
            var GetAllArtists = await ServiceForArtist.GetAllAsync();
            
            var CheckUser = GetAllUsers.FirstOrDefault(e => e.Email == auth.Email && e.Password == auth.Password);
            if(CheckUser != null && CheckUser.Role == Roles.User)
            {
                return AuthResult.UserAuthenticated;
            }

            var CheckArtist = GetAllArtists.FirstOrDefault(e => e.Email == auth.Email && e.Password == auth.Password);
            if (CheckArtist != null && CheckArtist.Role == Roles.Artist)
            {
                return AuthResult.ArtistAuthenticated;
            }

            var CheckAdmin = GetAllArtists.FirstOrDefault(e => e.Email == "admin" && e.Password == "admin");
            if (CheckArtist != null)
            {
                return AuthResult.Admin;
            }

            return AuthResult.AuthenticationFailed;




        }
    }
}
