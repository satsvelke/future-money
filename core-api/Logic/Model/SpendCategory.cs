using System.ComponentModel.DataAnnotations;
using Api.Logic.Model;

namespace core_api.Logic.Model
{
    public class SpendCategory : ColumnContext
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}