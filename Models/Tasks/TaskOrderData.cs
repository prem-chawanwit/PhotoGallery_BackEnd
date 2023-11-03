﻿namespace PhotoGallery_BackEnd.Models.Tasks
{
    [Table("API_TaskOrderData")]
    public class TaskOrderData
    {
        [Key]
        public int id { get; set; }
        public SectionUploadPathData sectionUploadPathData { get; set; }
        public SectionUploadSettingData sectionUploadSettingData { get; set; }
        public SectionConvertSettingData sectionConvertSettingData { get; set; }
    }
}
