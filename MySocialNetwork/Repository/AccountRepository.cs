using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySocialNetwork.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MySocialNetwork.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ILogger<AccountRepository> _logger;

        private readonly DatabaseConfiguration _configuration;

        public AccountRepository(IOptionsMonitor<DatabaseConfiguration> options, ILogger<AccountRepository> logger)
        {
            _configuration = options.CurrentValue;
            _logger = logger;
        }

        public async ValueTask<Account[]> ReadAccountsAsync(int count, CancellationToken cancellationToken)
        {
            try
            {
                using (var db = new MyDbContext())
                {

                    var topAccounts = await db.SubscribeModels.GroupBy(x => x.accountId)
                        .Select(x => new { id = x.Key, count = x.Count() })
                        .OrderBy(x => x.count)
                        .Take(count)
                        .Select(x => x.id)
                        .ToListAsync();

                    var accounts = await db.Accounts.Where(x => topAccounts.Contains(x.Id)).ToArrayAsync();

                    return accounts;
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retriving: {message}", ex.Message);
            }
            return new Account[0];
        }

        public async ValueTask RegisterAsync(Account account, CancellationToken cancellationToken)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    await db.Accounts.AddAsync(account);

                    await db.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while registering: {message}", ex.Message);
            }           
        }

        public async ValueTask SibscribeAsync(SubscribeModel entity, CancellationToken cancellationToken)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    await db.SubscribeModels.AddAsync(entity, cancellationToken);

                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while subscribing: {message}", ex.Message);
            }            
        }
    }
}
