using System.Text.Json.Serialization;

namespace TimeSheet.WebAPI.DTOs
{
    public class ClientDTO
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public int CountryId { get; set; }

        public ClientDTO() { }
        public ClientDTO(string? name, string? address, string? city, string? postalCode, int countryId)
        {
            Name = name;
            Address = address;
            City = city;
            PostalCode = postalCode;
            CountryId = countryId;
        }

    }
}