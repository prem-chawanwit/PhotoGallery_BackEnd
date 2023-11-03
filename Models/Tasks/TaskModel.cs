namespace PhotoGallery_BackEnd.Models.Tasks
{
    [Table("API_TaskModel")]
    public class TaskModel
    {
        [Key]
        public int id { get; set; }
        public string taskid { get; set; }
        public string owner { get; set; } = "user_demo";
        public DateTime dateCreated { get; set; } = DateTime.Now;
        public TaskStatus status { get; set; }
        // Navigation properties for relationships
        public int uploadPathDataid { get; set; } // Foreign key for UploadPathData
        public SectionUploadPathData? uploadPathData { get; set; }
        public int uploadSettingDataid { get; set; } // Foreign key for UploadSettingData
        public SectionUploadSettingData uploadSettingData { get; set; }
        public int convertSettingDataid { get; set; } // Foreign key for ConvertSettingData
        public SectionConvertSettingData convertSettingData { get; set; }
        public int TaskReviewDataid { get; set; } // Foreign key for TaskReviewid
        public TaskReviewData taskReviewData { get; set; }
        public string connectionid { get; set; } = string.Empty;
        // Add any other properties as needed
    }
}
