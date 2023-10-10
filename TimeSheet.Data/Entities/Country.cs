using System.ComponentModel.DataAnnotations;

namespace TimeSheet.Data.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public Country() { }    
        public Country(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}