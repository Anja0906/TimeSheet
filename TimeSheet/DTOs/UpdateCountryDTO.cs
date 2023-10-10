namespace TimeSheet.WebAPI.DTOs
{
    public class UpdateCountryDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public UpdateCountryDTO() { }
        public UpdateCountryDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
