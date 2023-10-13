namespace TimeSheet.WebAPI.DTOs
{
    public class LoginRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginRequestDTO()
        {
        }

        public LoginRequestDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
