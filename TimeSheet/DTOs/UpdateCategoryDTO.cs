namespace TimeSheet.WebAPI.DTOs
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public UpdateCategoryDTO() { }
        public UpdateCategoryDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
