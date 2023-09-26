using DreamGallery.Service.DTOs.Artist;

namespace DreamGallery.Service.Interfaces
{
    public interface IArtistService
    {
        public Task<ArtistForResultDto> CreateAsync(ArtistForCreationDto dto);
        public Task<ArtistForResultDto> UpdateAsync(ArtistForUpdateDto dto);
        public Task<bool> RemoveAsync(long Id);
        public Task<ArtistForResultDto> GetByIdAsync(long Id);
        public Task<List<ArtistForResultDto>> GetAllAsync();
    }
}
