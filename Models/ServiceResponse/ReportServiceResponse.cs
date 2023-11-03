namespace PhotoGallery_BackEnd.Models.ServiceResponse
{
    public class ReportServiceResponse<T>
    {
        public T? data { get; set; }
        public Dictionary<string, List<DropdownOption>> dataDropDown { get; set; } //Use a dictionary to associate dropdown options with columns
        public int? itemsPerPage { get; set; }
        public int? currentPage { get; set; }
        public int? itemTotal { get; set; }
        public int? itemFilter { get; set; }
        public bool success { get; set; } = true;
        public string message { get; set; } = string.Empty;
    }
}
