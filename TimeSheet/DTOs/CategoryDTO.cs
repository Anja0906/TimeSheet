namespace TimeSheet.WebAPI.DTOs
{
    public class CategoryDTO
    {
        public string? Name { get; set; }

        public CategoryDTO() { }
        public CategoryDTO(string name) {  Name = name; }

    }
}
