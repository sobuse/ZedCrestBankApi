using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZedCrestBankApi.Models
{
    [Table("Transcations")]
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string TranscationUniqueReference { get; set; }
        public decimal TranscationAmount { get; set; }
        public TranStatus TranscationStatus { get; set; }
        public bool IsSuccessful => TranscationStatus.Equals(TranStatus.Sucess);
        public string TranscationSourceAccount { get; set; }
        public string TranscationDestinationAccount { get; set; }
        public string TransactionParticulars { get; set; }
        public TranType TranscationType { get; set; }
        public DateTime TranscationDate { get; set; }

        public Transaction()
        {
            TranscationUniqueReference = $"{Guid.NewGuid().ToString().Replace("-","").Substring(1,17)}";
        }
    }  

    public enum TranStatus
    {
        Failed,
        Sucess,
        Error
    }

    public enum TranType
    {
        Deposit,
        Withdrawal,
        Transfer
    }
}
