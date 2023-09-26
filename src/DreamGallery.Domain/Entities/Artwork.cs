using DreamGallery.Domain.Commons;
using DreamGallery.Domain.Enums;

namespace DreamGallery.Domain.Entities
{
    public class Artwork : Auditable
    {
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public string Desciption { get; set; }
        public string Year { get; set; }
        public decimal Price { get; set; }
        public ArtCategory Category { get; set;} 
    }
}
