namespace PhotoGallery_BackEnd.DTOs.Tasks
{
    public class ViewTaskScheduleDTO
    {
        public int id { get; set; }
        public string? jobId { get; set; }
        public string? isRunning { get; set; }
        public string? lastExecute { get; set; }
    }
}
