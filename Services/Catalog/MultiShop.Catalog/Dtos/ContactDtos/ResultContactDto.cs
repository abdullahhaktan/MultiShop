namespace MultiShop.Catalog.Dtos.ContactDtos
{
    public class ResultContactDto
    {
        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime SendDate { get; set; } = DateTime.Now;
    }
}
