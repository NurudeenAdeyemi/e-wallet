namespace ewallet.Entities
{
    public class Wallet
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Balance { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
    }
}
