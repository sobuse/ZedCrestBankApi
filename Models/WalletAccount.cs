using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZedCrestBankApi.Models
{
    [Table("Wallets")]
    public class WalletAccount
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string WalletName { get; set; }
        public decimal CurrentWalletBalance { get; set; }
        public WalletType WalletType { get; set; }
        public string AccountNumberGenerator { get; set; }
        public string PhoneNumber { get; set; }

        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PinSalt { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdated { get; set; }

        Random rand = new Random();

        public WalletAccount() 
        { 
            AccountNumberGenerator = Convert.ToString((long) Math.Floor(rand.NextDouble() * 9_000_000_000L + 1_000_000_000L));
            WalletName = $"{FirstName} {LastName}";
        }


    }

    

    public enum WalletType
    {
        USD,
        NGN
    }
}
