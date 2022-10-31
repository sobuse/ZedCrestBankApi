using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZedCrestBankApi.Models;

namespace ZedCrestBankApi.Services
{
    public interface IWalletService
    {
        WalletAccount Authenticate(string WalletAccountNumber, string Pin);
        IEnumerable<WalletAccount> GetAllAccounts();
        WalletAccount Create(WalletAccount wallet, string Pin, string ComfirmPin);
        void Update(WalletAccount wallet, string Pin = null);
        void Delete( int Id);
        WalletAccount GetById(int Id);
        WalletAccount GetByWalletAccountNumber(string WalletAccountNumber);

    }
}
