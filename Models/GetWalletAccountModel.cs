using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZedCrestBankApi.Models
{
    public class GetWalletAccountModel
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string WalletName { get; set; }

        public decimal CurrentWalletBalance { get; set; }

        public WalletType WalletType { get; set; }

        public string AccountNumberGenerator { get; set; }

        public string PhoneNumber { get; set; }

        
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdated { get; set; }
    }
}
