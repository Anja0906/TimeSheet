namespace TimeSheet.WebAPI.DTOs
{
    public class CountryDTO
    {
        public string? Name { get; set; }

        public CountryDTO() { }
        public CountryDTO(string name) { Name = name; }
    }
}
