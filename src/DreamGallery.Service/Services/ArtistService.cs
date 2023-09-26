using DreamGallery.Data.Repositories;
using DreamGallery.Domain.Configurations;
using DreamGallery.Domain.Entities;
using DreamGallery.Service.DTOs.Artist;
using DreamGallery.Service.Exceptions;
using DreamGallery.Service.Interfaces;

namespace DreamGallery.Service.Services
{
    public class ArtistService : IArtistService
    {
        private long _id;
        Repository<Artist> ArtistRepository = new Repository<Artist>();
        public string Path = PathDb.UsersDb;
        public async Task<ArtistForResultDto> CreateAsync(ArtistForCreationDto dto)
        {
            await GenerateIdAsycAsync();
            var Check = (await ArtistRepository.SelectAllAsync()).FirstOrDefault(e => e.Email == dto.Email && e.Password == dto.Password);
            if (Check != null)
            {
                throw new DreamGalleryException(400, "This Artist exist in Database");
            }
            Artist Artist = new Artist()
            {
                Id = _id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                Balance = dto.Balance,
                Role = Domain.Enums.Roles.Artist,
            };
            await ArtistRepository.InsertAsync(Artist);

            ArtistForResultDto result = new ArtistForResultDto()
            {
                Id = _id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                Balance = dto.Balance,
                Role = Domain.Enums.Roles.Artist,


            };
            return result;

        }

        public async Task<List<ArtistForResultDto>> GetAllAsync()
        {
            var GetALlData = await ArtistRepository.SelectAllAsync();
            List<ArtistForResultDto> ls = new List<ArtistForResultDto>();
            foreach (var item in GetALlData)
            {
                ArtistForResultDto dto = new ArtistForResultDto()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Password = item.Password,
                    Balance = item.Balance,
                    Role = Domain.Enums.Roles.Artist,

                };
                ls.Add(dto);

            }
            return ls;
        }

        public async Task<ArtistForResultDto> GetByIdAsync(long Id)
        {
            var GetData = await ArtistRepository.SelectByIdAsync(Id);
            if(GetData == null)
            {
                throw new DreamGalleryException(404, "Not Found");
            }
            var result = new ArtistForResultDto()
            {
                Id = GetData.Id,
                FirstName = GetData.FirstName,
                LastName = GetData.LastName,
                Email = GetData.Email,
                Password = GetData.Password,
                Balance = GetData.Balance,
                Role = Domain.Enums.Roles.Artist,

            };
            return result;
        }

        public async Task<bool> RemoveAsync(long Id)
        {
            var GetData = await ArtistRepository.SelectByIdAsync(Id);
            if (GetData == null)
            {
                throw new DreamGalleryException(404, "Not Found");
            }
            var Result = await ArtistRepository.DeleteAsync(Id);
            return Result;
        }

        public async Task<ArtistForResultDto> UpdateAsync(ArtistForUpdateDto dto)
        {
            var Check = await ArtistRepository.SelectByIdAsync(dto.Id);
            if (Check == null)
            {
                throw new DreamGalleryException(404, "Not found");
            }
            var Artist = new Artist()
            {
                Id = Check.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                Balance = dto.Balance,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = Check.CreatedAt,
                Role = Domain.Enums.Roles.Artist,

            };
            await ArtistRepository.UpdateAsync(Artist);

            var result = new ArtistForResultDto()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                Balance = dto.Balance,
                Role = Domain.Enums.Roles.Artist,

            };

            return result;
        }
        public async Task GenerateIdAsycAsync()
        {
            var result = await ArtistRepository.SelectAllAsync();
            if (result.Count == 0)
            {
                _id = 1;
            }
            else
            {
                var res = result[result.Count - 1];
                _id = ++res.Id;
            }
        }
    }
}
