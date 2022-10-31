using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZedCrestBankApi.Models;

namespace ZedCrestBankApi.Services.Interface
{
    public interface ITransactionService
    {
        Response CreateNewTranscation(Transaction transcation);
        Response FindTransactionByDate(DateTime date);
        Response MakeDeposit(string WalletAccountNumber, decimal Amount, string TransactionPin);
        Response MAkeWithdrawal(string WalletAccountNumber, decimal Amount, string TransactionPin);
        Response MakeFundTransfer(string FromWalletAccount, string ToWalletAccount, decimal Amount, string TransactionPin);

    }
}
