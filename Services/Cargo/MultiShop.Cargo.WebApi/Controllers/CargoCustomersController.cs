using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinnessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCargoCustomers()
        {
            var values = await _cargoCustomerService.TGetAllAsync();

            var cargoCustomers = values.Select(c => new ResultCargoCustomer
            {
                CargoCustomerId = c.CargoCustomerId,
                Name = c.Name,
                Surname = c.Surname,
                Phone = c.Phone,
                District = c.District,
                City = c.City,
                Address = c.Address
            }).ToList(); // ← ToList() EKLENDİ!

            return Ok(cargoCustomers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoCustomerById(int id)
        {
            var value = await _cargoCustomerService.TGetByIdAsync(id);

            if (value == null)
                return NotFound();

            var result = new ResultCargoCustomer
            {
                CargoCustomerId = value.CargoCustomerId,
                Name = value.Name,
                Surname = value.Surname,
                Phone = value.Phone,
                District = value.District,
                City = value.City,
                Address = value.Address
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            var cargoCustomer = new CargoCustomer
            {
                Name = createCargoCustomerDto.Name,
                Surname = createCargoCustomerDto.Surname,
                Phone = createCargoCustomerDto.Phone,
                District = createCargoCustomerDto.District,
                City = createCargoCustomerDto.City,
                Address = createCargoCustomerDto.Address
            };

            await _cargoCustomerService.TInsertAsync(cargoCustomer);

            // 201 Created + yeni kaynağın URL'i
            return CreatedAtAction(nameof(GetCargoCustomerById), new { id = cargoCustomer.CargoCustomerId }, cargoCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoCustomer(int id)
        {
            var cargoCustomer = await _cargoCustomerService.TGetByIdAsync(id);

            if (cargoCustomer == null)
                return NotFound();

            await _cargoCustomerService.TDeleteAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoCustomer(UpdateCargoCustomer updateCargoCustomerDto)
        {
            var cargoCustomer = await _cargoCustomerService.TGetByIdAsync(updateCargoCustomerDto.CargoCustomerId);

            if (cargoCustomer == null)
                return NotFound();

            // Mapping EKLENDİ!
            cargoCustomer.Name = updateCargoCustomerDto.Name;
            cargoCustomer.Surname = updateCargoCustomerDto.Surname;
            cargoCustomer.Phone = updateCargoCustomerDto.Phone;
            cargoCustomer.District = updateCargoCustomerDto.District;
            cargoCustomer.City = updateCargoCustomerDto.City;
            cargoCustomer.Address = updateCargoCustomerDto.Address;

            await _cargoCustomerService.TUpdateAsync(cargoCustomer);
            return Ok(cargoCustomer); // Güncellenmiş entity'yi dön
        }
    }
}