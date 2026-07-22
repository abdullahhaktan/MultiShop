
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;

namespace MultiShop.Images.WebUi.Services
{
    public class CloudStorageService : ICloudStorageService
    {
        private readonly StorageClient _storageClient;
        private readonly string _bucketName;

        public CloudStorageService(IConfiguration configuration, IWebHostEnvironment env)
        {
            _bucketName = configuration["GCP:BucketName"];
            var relativePath = configuration["GCP:CredentialFilePath"];
            var credentialPath = Path.Combine(env.ContentRootPath, relativePath);

            var credential = GoogleCredential.FromFile(credentialPath);
            _storageClient = StorageClient.Create(credential);
        }

        public async Task<string> UploadFileAsync(IFormFile file, string fileNameToSave)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var dataObject = await _storageClient.UploadObjectAsync(
                bucket: _bucketName,
                objectName: fileNameToSave,
                contentType: file.ContentType,
                source: memoryStream);

            return dataObject.MediaLink;
        }
    }
}
