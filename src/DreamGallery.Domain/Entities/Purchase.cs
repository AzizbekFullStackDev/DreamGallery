using DreamGallery.Domain.Commons;

namespace DreamGallery.Domain.Entities
{
    public class Purchase : Auditable
    {
        public int UserId { get; set; }
        public int ArtworkId { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
