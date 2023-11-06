namespace PhotoGallery_BackEnd.DTOs.Tasks
{
    public class TaskOrderDataDTO
    {
        public PhotoDTO? sectionUploadPathData { get; set; }
        public SectionUploadSettingDataDTO sectionUploadSettingData { get; set; }
        public SectionConvertSettingDataDTO sectionConvertSettingData { get; set; }
    }
}
