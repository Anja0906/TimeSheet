using System.ComponentModel.DataAnnotations;

namespace TimeSheet.Data.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public int CountryId { get; set; }
        public virtual Country? Country { get; set; }
    }
}
