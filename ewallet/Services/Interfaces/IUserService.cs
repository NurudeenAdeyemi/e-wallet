using ewallet.DTOs;

namespace ewallet.Services.Interfaces
{
    public interface IUserService
    {
        //register user
        RegisterUserResponse RegisterUser(RegisterUserRequest request);
        string? GenerateJwtToken(LoginRequest request);
    }
}
