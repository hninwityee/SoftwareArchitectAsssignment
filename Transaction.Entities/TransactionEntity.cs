using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Transaction.Entities
{

    [Table("TransactionLog")]
    public partial class TransactionEntity
    {
        [Key]
        [Required]
        [Column("TransactionID")]
        [StringLength(50)]
        public string Transaction_Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [Column("CurrencyCode")]
        [StringLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime TransactionDate { get; set; }

        [Required]
        [Column("Status")]
        public string Status { get; set; }

        [Required]
        [Column("InputSource")]
        [StringLength(3)]
        public string InputSource { get; set; }

    }

    public partial class TransactionOutputEntity
    {
        public string id { get; set; }
        public string payment { get; set; }
        public string status { get; set; }
    }
}
