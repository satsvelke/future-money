using Api.Logic.Model;
using core_api.Logic.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Logic.DatabaseContext
{
    public class FmContext : DbContext
    {
        public FmContext(DbContextOptions<FmContext> options) : base(options)
        {

        }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanPaymentHistory> LoanPaymentHistories { get; set; }
        public DbSet<SpendCategory> SpendCategories { get; set; }
        public DbSet<Spend> Spent { get; set; }

    }
}
