using DreamGallery.Data.Repositories;
using DreamGallery.Domain.Configurations;
using DreamGallery.Domain.Entities;
using DreamGallery.Service.DTOs.Artist;
using DreamGallery.Service.DTOs.Artwork;
using DreamGallery.Service.Exceptions;
using DreamGallery.Service.Interfaces;

namespace DreamGallery.Service.Services
{
    internal class ArtworkService : IArtworkService
    {
        private long _id;
        Repository<Artwork> ArtworkRepository = new Repository<Artwork>();
        public string Path = PathDb.UsersDb;
        public async Task<ArtworkForResultDto> CreateAsync(ArtworkForCreationDto dto)
        {
            await GenerateIdAsycAsync();
            var Check = (await ArtworkRepository.SelectAllAsync()).FirstOrDefault(e => e.Title == dto.Title);
            if (Check != null)
            {
                throw new DreamGalleryException(400, "This Artwork exist in Database");
            }
            Artwork Artwork = new Artwork()
            {
                Id = _id,
                ArtistId = dto.ArtistId,
                Title = dto.Title,
                Category = dto.Category,
                Desciption = dto.Desciption,
                Price = dto.Price,
                Year = dto.Year,
            };
            await ArtworkRepository.InsertAsync(Artwork);

            ArtworkForResultDto result = new ArtworkForResultDto()
            {
                Id = _id,
                ArtistId = dto.ArtistId,
                Title = dto.Title,
                Category = dto.Category,
                Desciption = dto.Desciption,
                Price = dto.Price,
                Year = dto.Year,
                

            };
            return result;

        }

        public async Task<List<ArtworkForResultDto>> GetAllAsync()
        {
            var GetALlData = await ArtworkRepository.SelectAllAsync();
            List<ArtworkForResultDto> ls = new List<ArtworkForResultDto>();
            foreach (var item in GetALlData)
            {
                ArtworkForResultDto dto = new ArtworkForResultDto()
                {
                    Id = _id,
                    ArtistId = item.ArtistId,
                    Title = item.Title,
                    Category = item.Category,
                    Desciption = item.Desciption,
                    Price = item.Price,
                    Year = item.Year,


                };
                ls.Add(dto);

            }
            return ls;
        }

        public async Task<ArtworkForResultDto> GetByIdAsync(long Id)
        {
            var GetData = await ArtworkRepository.SelectByIdAsync(Id);
            if (GetData == null)
            {
                throw new DreamGalleryException(404, "Not Found");
            }
            var result = new ArtworkForResultDto()
            {
                Id = _id,
                ArtistId = GetData.ArtistId,
                Title = GetData.Title,
                Category = GetData.Category,
                Desciption = GetData.Desciption,
                Price = GetData.Price,
                Year = GetData.Year,

            };
            return result;
        }

        public async Task<bool> RemoveAsync(long Id)
        {
            var GetData = await ArtworkRepository.SelectByIdAsync(Id);
            if (GetData == null)
            {
                throw new DreamGalleryException(404, "Not Found");
            }
            var Result = await ArtworkRepository.DeleteAsync(Id);
            return Result;
        }

        public async Task<ArtworkForResultDto> UpdateAsync(ArtworkForUpdateDto dto)
        {
            var Check = await ArtworkRepository.SelectByIdAsync(dto.Id);
            if (Check == null)
            {
                throw new DreamGalleryException(404, "Not found");
            }
            var Artwork = new Artwork()
            {
                Id = _id,
                ArtistId = Check.ArtistId,
                Title = dto.Title,
                Category = Check.Category,
                Desciption = dto.Desciption,
                Price = dto.Price,
                Year = dto.Year,


            };
            await ArtworkRepository.UpdateAsync(Artwork);

            var result = new ArtworkForResultDto()
            {
                Id = _id,
                ArtistId = dto.ArtistId,
                Title = dto.Title,
                Category = dto.Category,
                Desciption = dto.Desciption,
                Price = dto.Price,
                Year = dto.Year,

            };

            return result;
        }
        public async Task GenerateIdAsycAsync()
        {
            var result = await ArtworkRepository.SelectAllAsync();
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
