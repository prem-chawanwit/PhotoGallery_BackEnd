namespace PhotoGallery_BackEnd.Models.ServiceResponse
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public UserDto? User { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
