using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZedCrestBankApi.Models;
using ZedCrestBankApi.Services.Interface;
using ZedCrestBankApi.Utilities;
using ZedCrestBankApi.ZDbContext;

namespace ZedCrestBankApi.Services.Implementation
{
    public class TransactionService : ITransactionService
    {
        private ZedCrestBankingApiContext _dbContext;
        ILogger<TransactionService> _logger;
        private AppSettings  _appSetting;

        public TransactionService(ZedCrestBankingApiContext dbContext) => _dbContext = dbContext;


        public Response CreateNewTranscation(Transaction transcation)
        {
            throw new NotImplementedException();
        }

        public Response FindTransactionByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Response MakeDeposit(string WalletAccountNumber, decimal Amount, string TransactionPin)
        {
            throw new NotImplementedException();
        }

        public Response MakeFundTransfer(string FromWalletAccount, string ToWalletAccount, decimal Amount, string TransactionPin)
        {
            throw new NotImplementedException();
        }

        public Response MAkeWithdrawal(string WalletAccountNumber, decimal Amount, string TransactionPin)
        {
            throw new NotImplementedException();
        }
    }
}
