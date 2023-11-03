namespace PhotoGallery_BackEnd.Models.Users
{
    [Table("API_Users")]
    public class User
    {
        public int id { get; set; }
        public string username { get; set; } = string.Empty;
        public byte[] passwordHash { get; set; } = null;
        public byte[] passwordSalt { get; set; } = null;
        public UserAccessLevel userAccessLevels { get; set; }
        public int userAccessLevelid { get; set; } = 3;
    }
}