using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedCrestBankApi.Models;
using ZedCrestBankApi.ZDbContext;

namespace ZedCrestBankApi.Services.Implementation
{
    public class WalletService : IWalletService
    {
        private ZedCrestBankingApiContext _dbContext;

        public WalletService(ZedCrestBankingApiContext dbContext) => _dbContext = dbContext;



        //public WalletAccount Authenticate(string WalletAccountNumber, string Pin)
        public WalletAccount Authenticate(string RegisterNewWalletAccountModel, string Pin)
        {

            var wallet = _dbContext.WalletAccounts.Where(x => x.AccountNumberGenerator == RegisterNewWalletAccountModel).SingleOrDefault();
            if (wallet == null)
                return null;
            //we have a match
            //verify pinHash
            if (!VerifyPinHash(Pin, wallet.PasswordHash, wallet.PinSalt))
                return null;

            return wallet;
        }
        private static bool VerifyPinHash(string pin, byte[] pinHash, byte[] pinSalt)
        {
            if (string.IsNullOrWhiteSpace(pin)) throw new ArgumentNullException("pin");
            //verify pin
            using (var hmac = new System.Security.Cryptography.HMACSHA512(pinSalt))
            {
                var computedPinHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pin));
                for (int i=0; i < computedPinHash.Length; i++)
                {
                    if (computedPinHash[i] != pinHash[i]) return false;
                }
               
            }
            return true;
        }

        public WalletAccount Create(WalletAccount wallet, string Pin, string ComfirmPin)
        {
            //email validation
            if (_dbContext.WalletAccounts.Any(x => x.Email == wallet.Email)) throw new ApplicationException("An account already exists with this email");


            //password validation
            if (!Pin.Equals(ComfirmPin)) throw new  ArgumentException("Pins do not match", "Pin");

            //hashing/ encrypting
            byte[] pinHash, pinSalt;
            CreatePinHash(Pin, out pinHash, out pinSalt);

            wallet.PasswordHash = pinHash;
            wallet.PinSalt = pinSalt;

            //adding new walllet to table
            _dbContext.WalletAccounts.Add(wallet);
            _dbContext.SaveChanges();

            return wallet;
        }

        private static void CreatePinHash(string pin, out byte[] pinHash, out byte[] pinSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                pinSalt = hmac.Key;
                pinHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pin));
            }
        }

        public void Delete(int Id)
        {
            var wallet = _dbContext.WalletAccounts.Find(Id);
            if(wallet != null)
            {
                _dbContext.WalletAccounts.Remove(wallet);
                _dbContext.SaveChanges();
            }
            
        }

        public IEnumerable<WalletAccount> GetAllAccounts()
        {
            return _dbContext.WalletAccounts.ToList();
        }

        public WalletAccount GetById(int Id)
        {
            var wallet = _dbContext.WalletAccounts.Where(x => x.Id == Id).FirstOrDefault();
            if (wallet == null) return null;
            return wallet;
        }

        public WalletAccount GetByWalletAccountNumber(string WalletAccountNumber)
        {
            var wallet = _dbContext.WalletAccounts.Where(x => x.AccountNumberGenerator == WalletAccountNumber).FirstOrDefault();
            if (wallet == null) return null;

            return wallet;
        }

        public void Update(WalletAccount wallet, string Pin = null)
        {
            var walletToBeUpdated = _dbContext.WalletAccounts.Where(x => x.Email == wallet.Email).SingleOrDefault();
            if (walletToBeUpdated == null) throw new ApplicationException("Wallet does not exist");

            //if its exist, lets listen for user wanting to change any of his properties
            if (!string.IsNullOrWhiteSpace(wallet.Email))
            {
                if (_dbContext.WalletAccounts.Any(x => x.Email == wallet.Email)) throw new ApplicationException("This Email" + wallet.Email + "already exists");

                walletToBeUpdated.Email = wallet.Email;
            }

            if (!string.IsNullOrWhiteSpace(wallet.PhoneNumber))
            {
                if (_dbContext.WalletAccounts.Any(x => x.PhoneNumber == wallet.PhoneNumber)) throw
                        new ApplicationException("This Phone" + wallet.PhoneNumber + "already exist");

                walletToBeUpdated.PhoneNumber = wallet.PhoneNumber;
            }

            if (!string.IsNullOrWhiteSpace(Pin))
            {
                byte[] pinHash, pinSalt;
                CreatePinHash(Pin, out pinHash, out pinSalt);

                walletToBeUpdated.PasswordHash = pinHash;
                walletToBeUpdated.PinSalt = pinSalt;
                walletToBeUpdated.DateLastUpdated = DateTime.Now;
 

            }

            walletToBeUpdated.DateLastUpdated = DateTime.Now;

            _dbContext.WalletAccounts.Update(walletToBeUpdated);
            _dbContext.SaveChanges();
        }
    }
}
