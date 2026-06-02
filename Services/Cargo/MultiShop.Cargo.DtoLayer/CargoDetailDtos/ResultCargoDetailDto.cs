using MultiShop.Cargo.DtoLayer.CargoCompanyDtos;

namespace MultiShop.Cargo.DtoLayer.CargoDetailDtos
{
    public class ResultCargoDetailDto
    {
        public int CargoDetailId { get; set; }
        public string SenderCustomer { get; set; }
        public string ReceiverCustomer { get; set; }
        public int Barcode { get; set; }

        public int CargoCompanyId { get; set; }
        public ResultCargoCompanyDto CargoCompany { get; set; }
    }
}
