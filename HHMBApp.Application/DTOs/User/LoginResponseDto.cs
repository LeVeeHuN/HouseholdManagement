namespace HHMBApp.Application.DTOs.User;

public class LoginResponseDto
{
    public Guid UserId { get; set; }
    public string? JwtToken { get; set; }
    public LoginResponseStatus Result { get; set; }
}

public enum LoginResponseStatus
{
    OK = 0,
    LoginError = 1
}