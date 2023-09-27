using DreamGallery.Domain.Entities;
using DreamGallery.Service.DTOs.Artwork;

namespace DreamGallery.Service.Interfaces
{
    public interface IPurchaseService
    {
        public Task<Purchase> PurchaseAsync(Purchase purchase);
        public Task<List<Purchase>> GetMyCollectionAsync(long Id);
        public Task<List<ArtworkForSold>> GetMyAllPurchasedArtsAsync(long Id);
        public Task<List<Purchase>> GetAllPurchasedArtsAsync();
    }
}
