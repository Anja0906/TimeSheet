using TimeSheet.Core.Models;

namespace TimeSheet.WebAPI.DTOs
{
    public class ClientResponseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }

        public ClientResponseDTO()
        {
        }

        public ClientResponseDTO(int id, string? name, string? address, string? city, string? postalCode, int countryId, Country? country)
        {
            Id = id;
            Name = name;
            Address = address;
            City = city;
            PostalCode = postalCode;
            CountryId = countryId;
            Country = country;
        }
    }
}