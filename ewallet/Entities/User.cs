namespace ewallet.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = default!;
        public string Role { get; set; } = default!;
        public Wallet Wallet { get; set; }
    }
}
