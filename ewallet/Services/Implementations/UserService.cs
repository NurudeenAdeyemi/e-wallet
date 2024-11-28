using ewallet.DTOs;
using ewallet.Entities;
using ewallet.Repositories.Interfaces;
using ewallet.Services.Interfaces;

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
    }
}
