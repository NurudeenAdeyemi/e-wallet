using ewallet.Entities;

namespace ewallet.Repositories.Interfaces
{
    public interface IWalletRepository
    {
        Wallet AddWallet(Wallet wallet);
        Wallet Update(Wallet wallet);
        IEnumerable<Wallet> GetWallets();
        Wallet GetWallet(Guid id);
        Wallet GetUserWallet(Guid userId);
    }
}
