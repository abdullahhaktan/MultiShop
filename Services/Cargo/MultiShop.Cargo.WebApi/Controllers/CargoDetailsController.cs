using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinnessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCargoDetails()
        {
            var values = await _cargoDetailService.TGetAllAsync();

            var cargoDetails = values.Select(c => new ResultCargoDetailDto
            {
                CargoDetailId = c.CargoDetailId,
                SenderCustomer = c.SenderCustomer,
                ReceiverCustomer = c.ReceiverCustomer,
                Barcode = c.Barcode,
                CargoCompanyId = c.CargoCompanyId,
            }).ToList();

            return Ok(cargoDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoDetailById(int id)
        {
            var value = await _cargoDetailService.TGetByIdAsync(id);

            if (value == null)
                return NotFound();

            var cargoDetail = new GetCargoDetailByIdDto
            {
                CargoDetailId = value.CargoDetailId,
                SenderCustomer = value.SenderCustomer,
                ReceiverCustomer = value.ReceiverCustomer,
                Barcode = value.Barcode,
                CargoCompanyId = value.CargoCompanyId
            };

            return Ok(cargoDetail);
        }

        [HttpPost]
        public async Task<IActionResult> AddCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            var cargoDetail = new CargoDetail
            {
                SenderCustomer = createCargoDetailDto.SenderCustomer,
                ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                Barcode = createCargoDetailDto.Barcode,
                CargoCompanyId = createCargoDetailDto.CargoCompanyId
            };

            await _cargoDetailService.TInsertAsync(cargoDetail);

            return CreatedAtAction(nameof(GetCargoDetailById), new { id = cargoDetail.CargoDetailId }, cargoDetail);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoDetail(int id)
        {
            var value = await _cargoDetailService.TGetByIdAsync(id);

            if (value == null)
                return NotFound();

            await _cargoDetailService.TDeleteAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode = updateCargoDetailDto.Barcode,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
                CargoDetailId = updateCargoDetailDto.CargoDetailId,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                SenderCustomer = updateCargoDetailDto.ReceiverCustomer
            };

            await _cargoDetailService.TUpdateAsync(cargoDetail);
            return Ok(cargoDetail);
        }
    }
}