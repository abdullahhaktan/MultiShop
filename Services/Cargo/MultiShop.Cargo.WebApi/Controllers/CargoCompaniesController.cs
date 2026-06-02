using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinnessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCargoCompanies()
        {
            var values = await _cargoCompanyService.TGetAllAsync();

            var cargoes = values.Select(c => new ResultCargoCompanyDto
            {
                CargoCompanyId = c.CargoCompanyId,
                CargoCompanyName = c.CargoCompanyName,
            }).ToList();

            return Ok(cargoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoCompanyById(int id)
        {
            var value = await _cargoCompanyService.TGetByIdAsync(id);

            if (value == null)
                return NotFound();

            var result = new ResultCargoCompanyDto
            {
                CargoCompanyId = value.CargoCompanyId,
                CargoCompanyName = value.CargoCompanyName
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            var cargoCompany = new CargoCompany
            {
                CargoCompanyName = createCargoCompanyDto.CargoCompanyName
            };

            await _cargoCompanyService.TInsertAsync(cargoCompany);

            return CreatedAtAction(nameof(GetCargoCompanyById), new { id = cargoCompany.CargoCompanyId }, cargoCompany);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            var cargoCompany = await _cargoCompanyService.TGetByIdAsync(id);

            if (cargoCompany == null)
                return NotFound();

            await _cargoCompanyService.TDeleteAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            var cargoCompany = await _cargoCompanyService.TGetByIdAsync(updateCargoCompanyDto.CargoCompanyId);

            if (cargoCompany == null)
                return NotFound();

            cargoCompany.CargoCompanyName = updateCargoCompanyDto.CargoCompanyName;

            await _cargoCompanyService.TUpdateAsync(cargoCompany);
            return Ok(cargoCompany);
        }
    }
}