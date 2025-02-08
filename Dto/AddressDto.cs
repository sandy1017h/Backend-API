namespace server.DTOs
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string? AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int? UserId { get; set; }
       
    }
}
