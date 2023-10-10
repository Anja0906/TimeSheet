namespace TimeSheet.WebAPI.DTOs
{
    public class CategoryResponseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public CategoryResponseDTO() { }
        public CategoryResponseDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
