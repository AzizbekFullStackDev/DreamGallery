using DreamGallery.Domain.Commons;

namespace DreamGallery.Domain.Entities
{
    public class Exhibition : Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set;}
    }
}
