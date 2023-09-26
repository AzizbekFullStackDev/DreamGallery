using DreamGallery.Domain.Entities;

namespace DreamGallery.Service.Interfaces
{
    public interface IPurchaseService
    {
        public Task<Purchase> PurchaseAsync(Purchase purchase);
    }
}
