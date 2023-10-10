using System.ComponentModel.DataAnnotations;

namespace TimeSheet.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public Category() { }
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
