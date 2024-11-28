using ewallet.Context;
using ewallet.Entities;
using ewallet.Repositories.Interfaces;

namespace ewallet.Repositories.Implementations
{
    public class WalletRepository : IWalletRepository
    {
        protected readonly ApplicationDbContext _context;
        public WalletRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Wallet AddWallet(Wallet wallet)
        {
            _context.Wallets.Add(wallet);
            _context.SaveChanges();
            return wallet;
        }

        public Wallet GetUserWallet(Guid userId)
        {
            var wallet = _context.Wallets.SingleOrDefault(w => w.UserId == userId);
            return wallet;
        }

        public Wallet GetWallet(Guid id)
        {
            var wallet = _context.Wallets.SingleOrDefault(w => w.Id == id);
            return wallet;
        }

        public IEnumerable<Wallet> GetWallets()
        {
           return _context.Wallets.ToList();
        }

        public Wallet Update(Wallet wallet)
        {
            _context.Wallets.Update(wallet);
            _context.SaveChanges();
            return wallet;
        }
    }
}
