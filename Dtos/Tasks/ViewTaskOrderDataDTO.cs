using PhotoGallery_BackEnd.DTOs.Task;

namespace PhotoGallery_BackEnd.DTOs.Tasks
{
    public class ViewTaskOrderDataDTO
    {
        public SectionGetUploadPathDataDTO? sectionGetUploadPathData { get; set; }
        public SectionUploadSettingDataDTO sectionUploadSettingData { get; set; }
        public SectionConvertSettingDataDTO sectionConvertSettingData { get; set; }
    }
}
