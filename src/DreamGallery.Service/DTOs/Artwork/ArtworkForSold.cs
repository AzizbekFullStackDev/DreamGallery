using DreamGallery.Domain.Enums;

namespace DreamGallery.Service.DTOs.Artwork
{
    public class ArtworkForSold
    {
        public long Id { get; set; }
        public string Customer { get; set; } 
        public string Title { get; set; }
        public long ArtistId { get; set; }
        public string Desciption { get; set; }
        public decimal Price { get; set; }
        public ArtCategory Category { get; set; }
    }
}
