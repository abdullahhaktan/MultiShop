using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinnessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCargoOperations()
        {
            var values = await _cargoOperationService.TGetAllAsync();

            var cargoOperations = values.Select(c => new ResultCargoOperationDto
            {
                CargoOperationId = c.CargoOperationId,
                Barcode = c.Barcode,
                Description = c.Description,
                OperationDate = c.OperationDate
            }).ToList();

            return Ok(cargoOperations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoOperationById(int id)
        {
            var value = await _cargoOperationService.TGetByIdAsync(id);

            if (value == null)
                return NotFound();

            var result = new GetCargoOperationByIdDto
            {
                CargoOperationId = value.CargoOperationId,
                Barcode = value.Barcode,
                Description = value.Description,
                OperationDate = value.OperationDate
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            var cargoOperation = new CargoOperation
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate
            };

            await _cargoOperationService.TInsertAsync(cargoOperation);

            return CreatedAtAction(nameof(GetCargoOperationById), new { id = cargoOperation.CargoOperationId }, cargoOperation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoOperation(int id)
        {
            var cargoOperation = await _cargoOperationService.TGetByIdAsync(id);

            if (cargoOperation == null)
                return NotFound();

            await _cargoOperationService.TDeleteAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            var value = await _cargoOperationService.TGetByIdAsync(updateCargoOperationDto.CargoOperationId);

            if (value == null)
                return NotFound();

            CargoOperation cargoOperation = new CargoOperation()
            {
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                Barcode = updateCargoOperationDto.Barcode,
                Description = updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate
            };

            await _cargoOperationService.TUpdateAsync(cargoOperation);
            return Ok(cargoOperation);
        }
    }
}