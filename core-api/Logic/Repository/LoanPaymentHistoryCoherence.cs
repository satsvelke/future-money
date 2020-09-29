using System;
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
    public class LoanPaymentHistoryCoherence : ILoanPaymentHistory
    {
        private readonly IMapper imapper;
        private readonly IApplicationUser iApplicationUser;
        private readonly FmContext context;
        private readonly string loggedInUser;
        public LoanPaymentHistoryCoherence(FmContext _context, IMapper _imapper, IApplicationUser _iApplicationUser)
        {
            context = _context;
            imapper = _imapper;
            iApplicationUser = _iApplicationUser;
            loggedInUser = iApplicationUser.GetUserId();
        }
        public async Task<LoanPaymentHistory> CreateAsync(LoanPaymentHistory tenet)
        {
            using (context)
            {
                context.Add(tenet);
                await context.SaveChangesAsync();
                return tenet;
            }
        }
        public async Task<bool> DeleteAsync(LoanPaymentHistory tenet)
        {
            using (context)
            {
                IQueryable<LoanPaymentHistory> query = context.LoanPaymentHistories.Where(x => x.LoanPaymentTransactionId == tenet.LoanPaymentTransactionId && x.IsActive == true);
                var existingTransaction = query.FirstOrDefault();

                if (existingTransaction == null)
                    return false;

                context.Entry(existingTransaction).State = EntityState.Detached;

                tenet.PendingAmount = existingTransaction.PendingAmount + existingTransaction.AmountPaid;
                tenet.IsActive = false;
                context.Attach(tenet);
                context.Entry(tenet).Property(x => x.IsActive).IsModified = true;
                context.Entry(tenet).Property(x => x.PendingAmount).IsModified = true;
                int isDone = await context.SaveChangesAsync();
                if (isDone > 0)
                    return true;
                else
                    return false;
            }
        }
        public async Task<IList<LoanPaymentHistory>> GetAllAsync()
        {
            using (context)
            {
                IQueryable<LoanPaymentHistory> query = context.LoanPaymentHistories.Where(x => x.IsActive == true && x.CreatedBy == loggedInUser);
                return await query.ToListAsync();
            }
        }
        public async Task<LoanPaymentHistory> GetByIdAsync(LoanPaymentHistory tenet)
        {
            using (context)
            {
                IQueryable<LoanPaymentHistory> query = context.LoanPaymentHistories.Where(x => x.IsActive == true && x.CreatedBy == loggedInUser && x.LoanPaymentTransactionId == tenet.LoanPaymentTransactionId);
                return await query.FirstOrDefaultAsync();
            }
        }
        public async Task<LoanPaymentHistory> UpdateAsync(LoanPaymentHistory tenet)
        {
            using (context)
            {
                tenet.PaidOn = DateTime.Now;
                context.Attach(tenet);
                context.Entry(tenet).Property(x => x.AmountPaid).IsModified = true;
                context.Entry(tenet).Property(x => x.PaidOn).IsModified = true;
                int isDone = await context.SaveChangesAsync();
                if (isDone > 0)
                    return tenet;
                else
                    return null;
            }
        }
    }
}