namespace PhotoGallery_BackEnd.Models.Users
{
    [Table("API_LoginTimming")]
    public class LoginTimming
    {
        public int id { get; set; }
        public string username { get; set; } = string.Empty;
        public DateTime lastLoggedIn { get; set; }
        public DateTime expireToken { get; set; }
        public bool isLoggedIn { get; set; }
    }
}