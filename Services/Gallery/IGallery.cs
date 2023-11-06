namespace PhotoGallery_BackEnd.Services.Gallery
{
    public interface IGallery
    {
        Task<ServiceResponse<string>> UploadPhoto(PhotoDTO request);
        Task<ServiceResponse<List<PhotoDTO>>> GetPhotoAll();
        Task<ServiceResponse<List<PhotoDTO>>> GetPhotoFilter(string photoName);
    }
}
