namespace PhotoGallery_BackEnd.Models.Tasks
{
    [Table("API_TaskReviewData")]
    public class TaskReviewData
    {
        [Key]
        public int id { get; set; }
        public string? task_id { get; set; }
        public string? extractData { get; set; }
        //Time
        public string? extractStartTime { get; set; }
        public string? extractEndTime { get; set; }
        //Status
        public string? extractSta { get; set; }
        public string? isRunning { get; set; }
        public string? remark { get; set; } = string.Empty;
    }
}
