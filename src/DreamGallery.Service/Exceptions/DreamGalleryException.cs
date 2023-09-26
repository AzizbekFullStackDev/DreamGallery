namespace DreamGallery.Service.Exceptions
{
    public class DreamGalleryException : Exception
    {
        public int StatusCode { get; set; }
        public DreamGalleryException(int code, string message) : base(message)
        {
            this.StatusCode = code;            
        }
    }
}
