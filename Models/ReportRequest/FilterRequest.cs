namespace PhotoGallery_BackEnd.Models.ReportRequest
{
    public class FilterRequest
    {
        public string keyFilter { get; set; }
        public string valueFilter { get; set; }
        public bool exactMatch { get; set; } = false;
    }
}
