using Microsoft.AspNetCore.Mvc;
using MultiShop.Images.WebUi.Services;

namespace MultiShop.Images.WebUi.Controllers
{
    public class ImageUploadController : Controller
    {
        private readonly ICloudStorageService _cloudStorageService;

        public ImageUploadController(ICloudStorageService cloudStorageService)
        {
            _cloudStorageService = cloudStorageService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                ViewBag.Error = "Lütfen geçerli bir resim seçiniz.";
            }

            string fileName = $"{Guid.NewGuid()}_{Path.GetFileName(imageFile.FileName)}";

            try
            {
                string uploadedFileUrl = await _cloudStorageService.UploadFileAsync(imageFile, fileName);
                ViewBag.Message = "Resim başarılya Google Cloud Bucket'a yüklendi";
                ViewBag.ImageUrl = uploadedFileUrl;
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Yükleme sırasında hata oluştu: {ex.Message}";
            }

            return View();
        }
    }
}
