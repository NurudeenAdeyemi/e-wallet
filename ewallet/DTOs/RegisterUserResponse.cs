namespace ewallet.DTOs
{
    public class RegisterUserResponse
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Guid WalletId { get; set; }
        public string Message { get; set; }
    }
}
