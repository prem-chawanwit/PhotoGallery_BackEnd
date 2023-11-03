namespace PhotoGallery_BackEnd.Models.Tasks
{
    [Table("API_SectionUploadPathData")]
    public class SectionUploadPathData
    {
        [Key]
        public int id { get; set; }
        public string dataSource { get; set; }
        public string basePath { get; set; } = string.Empty;
        public string? nameFile { get; set; } = string.Empty;
    }
}
