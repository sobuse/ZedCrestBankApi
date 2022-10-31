using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZedCrestBankApi.Models;

namespace ZedCrestBankApi.ZDbContext
{
    public class ZedCrestBankingApiContext : DbContext
    {
        public ZedCrestBankingApiContext(DbContextOptions<ZedCrestBankingApiContext> options) : base(options)
        {

        }

        public DbSet<WalletAccount> WalletAccounts { get; set; }
        public DbSet<Transaction> Transcations { get; set; }
    }
}
