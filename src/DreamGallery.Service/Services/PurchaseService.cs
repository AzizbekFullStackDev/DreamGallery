using DreamGallery.Data.Repositories;
using DreamGallery.Domain.Entities;
using DreamGallery.Service.Interfaces;

namespace DreamGallery.Service.Services
{
    public class PurchaseService : IPurchaseService
    {
        Repository<Purchase> PurchaseRepository = new Repository<Purchase>();
        private long _id;
        public async Task<Purchase> PurchaseAsync(Purchase purchase)
        {
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
