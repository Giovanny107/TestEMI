namespace TestEMI.Application.DTO_s
{
    public class RegisterUser : AuthRequest
    {
        public string Role { get; set; } = string.Empty;
    }
}
