using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Logic.Model;

namespace core_api.Logic.Model
{
    public class Spend : ColumnContext
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid SpendId { get; set; }
        public SpendCategory CategoryId { get; set; }
        public string Remarks { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MoneySpent { get; set; }

    }
}