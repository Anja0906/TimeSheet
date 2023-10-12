using System.ComponentModel.DataAnnotations;

namespace TimeSheet.Core.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
