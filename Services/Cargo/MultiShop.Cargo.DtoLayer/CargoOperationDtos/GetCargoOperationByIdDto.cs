namespace MultiShop.Cargo.DtoLayer.CargoOperationDtos
{
    public class GetCargoOperationByIdDto
    {
        public int CargoOperationId { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
