using DreamGallery.Service.DTOs.User;

namespace DreamGallery.Service.Interfaces
{
    public interface IUserService
    {
        public Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
        public Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto);
        public Task<bool> RemoveAsync(long Id);
        public Task<UserForResultDto> GetByIdAsync(long Id);    
        public Task<List<UserForResultDto>> GetAllAsync();    
    }
}
