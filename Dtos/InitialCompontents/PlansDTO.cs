namespace PhotoGallery_BackEnd.DTOs.InitialComponents.PlansDTO
{
    public class PlansDTO
    {
        public int id { get; set; }
        public string? planToUpload { get; set; } = string.Empty;
        public string? planToActive { get; set; } = string.Empty;
        public string? planDetails { get; set; } = string.Empty;
    }
}