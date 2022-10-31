using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZedCrestBankApi.Models
{
    public class RegisterNewWalletAccountModel
    {
       
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        //public string WalletName { get; set; }
        //public decimal CurrentWalletBalance { get; set; }
        public WalletType WalletType { get; set; }
        public string AccountNumberGenerator { get; set; }
        public string PhoneNumber { get; set; }

        //public byte[] PasswordHash { get; set; }
        // public byte[] PinSalt { get; set; }
        
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdated { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage= "Pin must not be more 4 digits")]//pin should be 4 digit
        public string Pin { get; set; }

        [Compare("Pin", ErrorMessage ="Pin do not match")]
        public string ConfirmPin { get; set; }// compare both pin

        
    }
}
