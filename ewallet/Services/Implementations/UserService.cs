using ewallet.DTOs;
using ewallet.Entities;
using ewallet.Repositories.Interfaces;
using ewallet.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ewallet.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public RegisterUserResponse RegisterUser(RegisterUserRequest request)
        {
            //check if user exist
            var userExist = _userRepository.UserExist(request.Email);
            if (userExist)
            {
                throw new Exception($"User with email: {request.Email} already exist ");
            }

            //create the user and the wallet
            var user = new User
            {
                FullName = request.Email,
                Email = request.Email,
                Password = request.Password,
                Role = "Customer",
                Wallet = new Wallet
                {
                    Balance = 0,
                    Transactions = []
                }
            };

            _userRepository.AddUser(user);
            return new RegisterUserResponse
            {
                UserId = user.Id.ToString(),
                FullName = user.FullName,
                Email = user.Email,
                WalletId = user.Wallet.Id,
                Message = "User and Wallet created successfully"

            };
        }


        public string? GenerateJwtToken(LoginRequest request)
        {
            var user = _userRepository.GetUser(request.Email);
            if (user == null)
            {
                return null;
            }

            if(user.Password != request.Password)
            {
                return null;
            }

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes("S0M3RAN0MS3CR3T!1!MAG1C!1!343456y674688847"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

            var allClaims = new List<Claim>(claims);

            var token = new JwtSecurityToken(
                issuer: "ewallet-api",
                audience: "your-client-id",
                claims: allClaims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
