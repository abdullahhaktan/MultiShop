namespace MultiShop.Images.WebUi.Services
{
    public interface ICloudStorageService
    {
        Task<string> UploadFileAsync(IFormFile file, string fileNameToSave);
    }
}
