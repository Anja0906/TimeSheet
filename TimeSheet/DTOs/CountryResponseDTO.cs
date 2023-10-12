namespace TimeSheet.WebAPI.DTOs
{
    public class CountryResponseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public CountryResponseDTO() { }
        public CountryResponseDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
