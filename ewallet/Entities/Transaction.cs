using ewallet.Enums;

namespace ewallet.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid WalletId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
