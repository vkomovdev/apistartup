using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using MySocialNetwork.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MySocialNetwork.Tests
{
    [TestClass]
    public class DBTests
    {

        [TestMethod]
        public void CreatDatabase() 
        {

            using (var db = new MyDbContext())
            {

                var isCreated = db.Database.EnsureCreated();

                Assert.IsTrue(isCreated);

                var accounts = db.Accounts.ToList();

                Assert.AreEqual(0, accounts.Count);
            }
            
        }
    }

}
