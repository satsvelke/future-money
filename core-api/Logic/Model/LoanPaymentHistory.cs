using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Logic.Model
{
    public class LoanPaymentHistory : ColumnContext
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid LoanPaymentTransactionId { get; set; }
        public DateTime PaidOn { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountPaid { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PendingAmount { get; set; }
    }
}
