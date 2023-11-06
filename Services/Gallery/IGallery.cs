namespace PhotoGallery_BackEnd.Services.Gallery
{
    public interface IGallery
    {
        Task<ServiceResponse<string>> UploadPhoto(PhotoDTO request);
        Task<ServiceResponse<string>> EditPhotoName(EditPhotoDTO request);
        Task<ServiceResponse<string>> DeletePhotoName(EditPhotoDTO request);
        Task<ServiceResponse<List<GetPhotoDTO>>> GetPhotoAll(string username);
        Task<ServiceResponse<List<GetPhotoDTO>>> GetPhotoFilter(GetPhotoFilterDTO request);
        Task<ServiceResponse<List<GetPhotoDTO>>> GetPhotoFilter(string photoName);
        Task<ServiceResponse<bool>> CheckUser(string username);
    }
}
