namespace PhotoGallery_BackEnd.Models.Users
{
    [Table("API_UserAccessLevel")]
    public class UserAccessLevel
    {
        [Key]
        public int id { get; set; }

        public int accessLevel { get; set; }

        public string accessLevelName { get; set; }
    }
}
