using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoFixture;
using Moq;
using System;
using MySocialNetwork.Repository;
using MySocialNetwork.Models;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace MySocialNetwork.Tests
{
    [TestClass]
    public class AccountTests
    {
        private static readonly DatabaseConfiguration Configurations;
        protected readonly Fixture Fixture = new Fixture();        
        protected IOptionsMonitor<DatabaseConfiguration> Options;

        static AccountTests()
        {
            Configurations = new DatabaseConfiguration
            {
                ConnectionString = ConfigurationHelper.Configurations.GetSection("ConnectionString").Value 
            };
        }

        [TestInitialize]
        public void InitializeTest()
        {
            Options = Mock.Of<IOptionsMonitor<DatabaseConfiguration>>(x => x.CurrentValue == Configurations);

            Fixture.Customizations.Add(new StringGenerator(() => Guid.NewGuid().ToString().Substring(0, 10)));
        }


        [TestMethod]
        public async Task RegisterAccount()
        {
            //arrange
            var readerLogger = Mock.Of<ILogger<AccountRepository>>();
            var sut = new AccountRepository(Options, readerLogger);

            var employee = Fixture.Build<Account>()              
                .Create();

            //act
            await sut.RegisterAsync(employee, new CancellationToken());

            var accounts = await sut.ReadAccountsAsync(1, new CancellationToken());

            //assert
            Assert.AreEqual(1, accounts.Length);

        }


        [TestCleanup]
        [Obsolete]
        public void TearDown()
        {
            using (var context = new MyDbContext())
            {
                var count = context.Database.ExecuteSqlCommand("DELETE FROM Accounts");
            }
        }
    }
}
