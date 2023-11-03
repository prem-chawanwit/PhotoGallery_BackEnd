namespace PhotoGallery_BackEnd.DTOs.Tasks
{
    public class ViewTaskDTO
    {
        public int id { get; set; }
        public string? taskid { get; set; } 
        public string? owner { get; set; } // update use task table
        public int status { get; set; }
        public string? dateCreated { get; set; } // update use task table
    }
}
