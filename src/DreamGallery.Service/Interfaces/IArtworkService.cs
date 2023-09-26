using DreamGallery.Service.DTOs.Artwork;

namespace DreamGallery.Service.Interfaces
{
    public interface IArtworkService
    {
        public Task<ArtworkForResultDto> CreateAsync(ArtworkForCreationDto dto);
        public Task<ArtworkForResultDto> UpdateAsync(ArtworkForUpdateDto dto);
        public Task<bool> RemoveAsync(long Id);
        public Task<ArtworkForResultDto> GetByIdAsync(long Id);
        public Task<List<ArtworkForResultDto>> GetAllAsync();

    }
}
