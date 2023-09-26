using DreamGallery.Domain.Commons;

namespace DreamGallery.Domain.Entities
{
    public class Purchase : Auditable
    {
        public long UserId { get; set; }
        public long ArtworkId { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
