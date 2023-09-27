using DreamGallery.Data.Repositories;
using DreamGallery.Domain.Entities;
using DreamGallery.Service.DTOs.Artwork;
using DreamGallery.Service.Interfaces;

namespace DreamGallery.Service.Services
{
    public class PurchaseService : IPurchaseService
    {
        Repository<Purchase> PurchaseRepository = new Repository<Purchase>();
        private long _id;
        public async Task<Purchase> PurchaseAsync(Purchase purchase)
        {
            await GenerateIdAsync();
            Purchase item = new Purchase()
            {
                UserId = purchase.UserId,
                Id = _id,
                ArtworkId = purchase.ArtworkId,
                PurchaseDate = DateTime.UtcNow,
            };
            await PurchaseRepository.InsertAsync(item);
            return item;
        }

        public async Task<List<Purchase>> GetMyCollectionAsync(long Id)
        {
            ArtworkService artworkService = new ArtworkService();
            var AllArtwork = (await PurchaseRepository.SelectAllAsync()).Where(e => e.UserId == Id).ToList();
            return AllArtwork;
        }
        public async Task<List<ArtworkForSold>> GetMyAllPurchasedArtsAsync(long Id)
        {
            var ArtworkService = new ArtworkService();
            var ArtworkAll = await ArtworkService.GetAllAsync();

            var UserService = new UserService();
            var AllUsers = await UserService.GetAllAsync();

            var AllPurchased = await PurchaseRepository.SelectAllAsync();
            var ConnectedArtworks = from purchased in AllPurchased
                                    join arts in ArtworkAll on
                                    purchased.ArtworkId equals arts.Id
                                    join users in AllUsers on
                                    purchased.UserId equals users.Id
                                    select new
                                    {
                                        artwork = arts,
                                        Customer = purchased,
                                        usersAll = users
                                    };
            List<ArtworkForSold> Collection = new List<ArtworkForSold>();
            var Result = ConnectedArtworks.Where(e => e.artwork.ArtistId == Id).ToList();
            foreach (var artwork in Result)
            {
                ArtworkForSold arts = new ArtworkForSold()
                {
                    Id = artwork.artwork.Id,
                    Customer = artwork.usersAll.FirstName,
                    ArtistId = artwork.artwork.ArtistId,
                    Title = artwork.artwork.Title,
                    Desciption = artwork.artwork.Desciption,
                    Category = artwork.artwork.Category,
                    Price = artwork.artwork.Price,
                };
                Collection.Add(arts);
            }

            return Collection;
        }
        public async Task<List<Purchase>> GetAllPurchasedArtsAsync()
        {
            var AllArtwork = await PurchaseRepository.SelectAllAsync();
            return AllArtwork;
        }
        public async Task GenerateIdAsync()
        {
            var result = await PurchaseRepository.SelectAllAsync();
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
