namespace PhotoGallery_BackEnd.Models.ReportRequest
{
    public class ClientRequest
    {
        public PageRequest page { get; set; }
        public List<FilterRequest> filterColumn { get; set; }
        public List<SortRequest> sortColumn { get; set; }
        public bool requestAllDropDown { get; set; } = true;
    }
}
