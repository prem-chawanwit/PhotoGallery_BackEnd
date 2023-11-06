namespace PhotoGallery_BackEnd.DTOs.Gallery
{
    public class PhotoDTO
    {
        public string requestUsername { get; set; }
        public string requestFileName { get; set; }
        public IFormFile requestFile { get; set; }
    }
}
