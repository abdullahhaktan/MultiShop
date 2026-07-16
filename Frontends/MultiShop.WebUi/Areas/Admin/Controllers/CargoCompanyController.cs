using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUi.Services.CargoServices.CargoCompanyServices;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CargoCompanyController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        public async Task<IActionResult> CargoCompanyList()
        {
            var values = await _cargoCompanyService.GetAllCargoCompanyAsync();
            return View(values ?? new List<ResultCargoCompanyDto>());
        }

        [HttpGet]
        public IActionResult CreateCargoCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            // Model veya parametre null ise işlemi durdurup formu tekrar gösteriyoruz
            if (createCargoCompanyDto == null || !ModelState.IsValid)
            {
                return View(createCargoCompanyDto);
            }

            await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDto);
            return RedirectToAction("CargoCompanyList", "CargoCompany", new { Area = "Admin" });
        }

        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            // Hatalı veya negatif id gönderimlerine karşı güvenlik kontrolü
            if (id <= 0)
            {
                return RedirectToAction("CargoCompanyList", "CargoCompany", new { Area = "Admin" });
            }

            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            return RedirectToAction("CargoCompanyList", "CargoCompany", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCargoCompany(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("CargoCompanyList", "CargoCompany", new { Area = "Admin" });
            }

            var values = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
            // Güncellenecek nesne API'den boş gelirse listeye geri yönlendiriyoruz
            if (values == null)
            {
                return RedirectToAction("CargoCompanyList", "CargoCompany", new { Area = "Admin" });
            }
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            // Gönderilen verinin null olması durumunu kontrol ediyoruz
            if (updateCargoCompanyDto == null || !ModelState.IsValid)
            {
                return View(updateCargoCompanyDto);
            }

            await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDto);
            return RedirectToAction("CargoCompanyList", "CargoCompany", new { Area = "Admin" });
        }
    }
}