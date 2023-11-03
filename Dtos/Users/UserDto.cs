namespace PhotoGallery_BackEnd.DTOs.Users
{
    public class UserDto
    {
        public string username { get; set; } = string.Empty;
        public int userAccessLevelid { get; set; } = 6;
        public string roles { get; set; } = "Unknown";
    }
}
