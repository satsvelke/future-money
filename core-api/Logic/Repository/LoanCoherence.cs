using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Logic.DatabaseContext;
using Api.Logic.Interface;
using Api.Logic.Model;
using AutoMapper;
using core_api.Logic.Interface;
using Microsoft.EntityFrameworkCore;

namespace core_api.Logic.Repository
{

    public class LoanCoherence : ILoan
    {
        private readonly IMapper imapper;
        private readonly IApplicationUser iApplicationUser;
        private readonly FmContext context;
        private readonly string loggedInUser;
        public LoanCoherence(FmContext _context, IMapper _imapper, IApplicationUser _iApplicationUser)
        {
            imapper = _imapper;
            iApplicationUser = _iApplicationUser;
            context = _context;
            loggedInUser = _iApplicationUser.GetUserId();
        }
        public async Task<Loan> CreateAsync(Loan tenet)
        {
            using (context)
            {
                tenet.CreatedBy = loggedInUser;
                tenet.FinalPendingAmount = tenet.AmountTaken;
                context.Loans.Add(tenet);
                await context.SaveChangesAsync();
                return tenet;
            }
        }

        public async Task<bool> DeleteAsync(Loan tenet)
        {
            using (context)
            {
                tenet.IsActive = false;
                context.Attach(tenet);
                context.Entry(tenet).Property(x => x.IsActive).IsModified = true;
                int isDone = await context.SaveChangesAsync();
                if (isDone > 0)
                    return true;
            }

            return false;
        }

        public async Task<IList<Loan>> GetAllAsync()
        {
            using (context)
            {
                IQueryable<Loan> query = context.Loans.Where(x => x.IsActive == true && x.CreatedBy == loggedInUser);
                return await query.ToListAsync();
            }
        }

        public async Task<Loan> GetByIdAsync(Loan tenet)
        {
            using (context)
            {
                IQueryable<Loan> query = context.Loans.Where(x => x.IsActive == true && x.LoanId == tenet.LoanId && x.CreatedBy == loggedInUser);
                return await query.FirstOrDefaultAsync();
            }
        }

        public async Task<Loan> UpdateAsync(Loan tenet)
        {
            using (context)
            {
                IQueryable<Loan> query = context.Loans.Where(x => x.IsActive == true && x.LoanId == tenet.LoanId && x.CreatedBy == loggedInUser);
                var existingLoanDetails = query.FirstOrDefault();
                var newAmount = (existingLoanDetails.AmountTaken - tenet.AmountTaken);
                if (newAmount < 0)
                    tenet.FinalPendingAmount = (-(newAmount)) + existingLoanDetails.FinalPendingAmount;

                if (newAmount > 0)
                    tenet.FinalPendingAmount = (-(newAmount)) + existingLoanDetails.FinalPendingAmount;

                if (newAmount == 0)
                    tenet.FinalPendingAmount = existingLoanDetails.FinalPendingAmount;

                context.Entry(existingLoanDetails).State = EntityState.Detached;

                context.Attach(tenet);
                context.Entry(tenet).Property(x => x.AmountTaken).IsModified = true;
                context.Entry(tenet).Property(x => x.TakenFrom).IsModified = true;
                context.Entry(tenet).Property(x => x.TakenOn).IsModified = true;
                context.Entry(tenet).Property(x => x.FinalPendingAmount).IsModified = true;
                await context.SaveChangesAsync();
                return tenet;
            }
        }
    }
}