namespace PhotoGallery_BackEnd.Models.Tasks
{
    [Table("API_SectionUploadPathData")]
    public class SectionUploadPathData
    {
        [Key]
        public int id { get; set; }
        public string basePath { get; set; } = string.Empty;
        public string nameFile { get; set; } = string.Empty;
        public string nameFileSystem { get; set; } = string.Empty;
        public string sizeFile { get; set; } = string.Empty;
        public string fileExtension { get; set; }
        public DateTime timeUpdated { get; set; }

    }
}
