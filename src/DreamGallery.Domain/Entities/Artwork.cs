using DreamGallery.Domain.Commons;
using DreamGallery.Domain.Enums;

namespace DreamGallery.Domain.Entities
{
    public class Artwork : Auditable
    {
        public string Title { get; set; }
        public long ArtistId { get; set; }
        public string Desciption { get; set; }
        public decimal Price { get; set; }
        public ArtCategory Category { get; set;} 
    }
}
