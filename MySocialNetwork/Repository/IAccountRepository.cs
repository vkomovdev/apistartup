using MySocialNetwork.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MySocialNetwork.Repository
{
    public interface IAccountRepository
    {
        ValueTask RegisterAsync(Account account, CancellationToken cancellationToken);

        ValueTask SibscribeAsync(SubscribeModel account, CancellationToken cancellationToken);

        ValueTask<Account[]> ReadAccountsAsync(int count, CancellationToken cancellationToken);
    }
}
