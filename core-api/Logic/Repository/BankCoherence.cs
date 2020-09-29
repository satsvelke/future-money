using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Logic.DatabaseContext;
using Api.Logic.Interface;
using Api.Logic.Model;
using Api.Logic.ViewModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Logic.Repository
{
    public class BankCoherence : IBank
    {
        private readonly IMapper imapper;
        private readonly IApplicationUser iApplicationUser;
        private readonly FmContext context;
        private readonly string loggedInUser;
        public BankCoherence(FmContext _context, IMapper _imapper, IApplicationUser _iApplicationUser)
        {
            context = _context;
            imapper = _imapper;
            iApplicationUser = _iApplicationUser;
            loggedInUser = iApplicationUser.GetUserId();
        }
        public async Task<BankView> CreateAsync(BankView tenet)
        {

            using (context)
            {
                var newBank = imapper.Map<Bank>(tenet);
                newBank.CreatedBy = loggedInUser;
                context.Add(newBank);
                await context.SaveChangesAsync();
                return imapper.Map<BankView>(newBank);
            }
        }
        public async Task<bool> DeleteAsync(BankView tenet)
        {
            using (context)
            {
                var bank = new Bank()
                {
                    BankId = tenet.BankId,
                    IsActive = false
                };
                context.Attach(bank);
                context.Entry(bank).Property(x => x.IsActive).IsModified = true;
                if (await context.SaveChangesAsync() > 0)
                    return true;
            }
            return false;
        }

        public async Task<IList<BankView>> GetAllAsync()
        {
            using (context)
            {
                IQueryable<Bank> query = context.Banks.Where(b => b.IsActive == true && b.CreatedBy == loggedInUser);
                return imapper.Map<IList<BankView>>(await query.ToListAsync());
            }
        }

        public async Task<BankView> GetByIdAsync(BankView tenet)
        {
            using (context)
            {
                IQueryable<Bank> query = context.Banks.Where(b => b.BankId == tenet.BankId && b.IsActive == true && b.CreatedBy == loggedInUser);
                return imapper.Map<BankView>(await query.FirstOrDefaultAsync());
            }
        }
        public async Task<BankView> UpdateAsync(BankView tenet)
        {
            using (context)
            {
                var newBank = imapper.Map<Bank>(tenet);
                context.Attach(newBank);
                context.Entry(newBank).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return imapper.Map<BankView>(newBank);
            }
        }
    }
}
