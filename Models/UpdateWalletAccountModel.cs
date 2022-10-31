using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZedCrestBankApi.Models
{
    public class UpdateWalletAccountModel
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]/d{4}$", ErrorMessage = "Pin must not be more 4 digits")]//pin should be 4 digit
        public string Pin { get; set; }

        [Compare("Pin", ErrorMessage = "Pin do not match")]
        public string ConfirmPin { get; set; }// compare both pin

        public DateTime DateLastUpdated { get; set; }
    }
}
