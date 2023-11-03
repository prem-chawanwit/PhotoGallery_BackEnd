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
        public int uploadPathDataid { get; set; }
        public SectionUploadPathData? uploadPathData { get; set; }
    }
}
