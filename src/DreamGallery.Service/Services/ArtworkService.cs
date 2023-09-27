using DreamGallery.Data.Repositories;
using DreamGallery.Domain.Configurations;
using DreamGallery.Domain.Entities;
using DreamGallery.Service.DTOs.Artist;
using DreamGallery.Service.DTOs.Artwork;
using DreamGallery.Service.Exceptions;
using DreamGallery.Service.Interfaces;

namespace DreamGallery.Service.Services
{
    public class ArtworkService : IArtworkService
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
                

            };
            return result;

        }

        public async Task<List<ArtworkForResultDto>> GetAllAsync()
        {
            var Purchase = new PurchaseService();
            var PurchasedArts = await Purchase.GetAllPurchasedArtsAsync();
            var GetALlData = await ArtworkRepository.SelectAllAsync();
            List<ArtworkForResultDto> ls = new List<ArtworkForResultDto>();

            foreach (var item in GetALlData)
            {
                var check = PurchasedArts.Where(e => e.ArtworkId == item.Id);

                if (!check.Any()) // Check if there are no purchased arts with the same ArtworkId
                {
                    ArtworkForResultDto dto = new ArtworkForResultDto()
                    {
                        Id = item.Id,
                        ArtistId = item.ArtistId,
                        Title = item.Title,
                        Category = item.Category,
                        Desciption = item.Desciption,
                        Price = item.Price,
                    };
                    ls.Add(dto);
                }
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
                Id = GetData.Id,
                ArtistId = GetData.ArtistId,
                Title = GetData.Title,
                Category = GetData.Category,
                Desciption = GetData.Desciption,
                Price = GetData.Price,

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
                Id = Check.Id,
                ArtistId = Check.ArtistId,
                Title = dto.Title,
                Category = Check.Category,
                Desciption = dto.Desciption,
                Price = dto.Price,


            };
            await ArtworkRepository.UpdateAsync(Artwork);

            var result = new ArtworkForResultDto()
            {
                Id = dto.Id,
                ArtistId = dto.ArtistId,
                Title = dto.Title,
                Category = dto.Category,
                Desciption = dto.Desciption,
                Price = dto.Price,

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
