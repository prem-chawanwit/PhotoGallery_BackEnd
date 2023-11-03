namespace PhotoGallery_BackEnd.DTOs.Tasks
{
    public class SectionConvertSettingDataDTO
    {
        public string convertSetting { get; set; }
        public string dueDate { get; set; } = string.Empty;
        public List<string> product { get; set; }
        public List<string> workOrder { get; set; }
        public List<string> apPlan { get; set; }
        public List<string> coProduct { get; set; }
        public List<string> boms { get; set; }
    }
}
