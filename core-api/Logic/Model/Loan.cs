using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Logic.Model
{
    public class Loan : ColumnContext
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid LoanId { get; set; }
        public string TakenFrom { get; set; }
        public string TakenOn { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountTaken { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal FinalPendingAmount { get; set; }
    }
}
