using DreamGallery.Data.Repositories;
using DreamGallery.Domain.Entities;
using DreamGallery.Presentation.Presentation;
using DreamGallery.Service.DTOs.Artist;
using DreamGallery.Service.Services;

namespace DreamGallery.Presentation
{
    public class Program
    {
        static async Task Main(string[] args)
        {
/*            Repository<Artist> artist = new Repository<Artist>();
            var Creation = new Artist()
            {
                Id = 1,
                Balance = 0,
                FirstName = "Test",
                LastName = "Test",
                Email = "Test",
                Password = "Test",
            };
            await artist.InsertAsync(Creation);*/
/*            ArtistService artistService = new ArtistService();
            ArtistForCreationDto artistForCreationDto = new ArtistForCreationDto()
            {
                Balance = 111,
                FirstName = "Salomat",
                LastName = "bo`ling",
                Email = "Salomaaa@",
                Password = "Donasasdase",
            };
            var result = await artistService.CreateAsync(artistForCreationDto);*/
            UserInterface userInterface = new UserInterface();
            await userInterface.RunCodeAsync();
        }
    }
}