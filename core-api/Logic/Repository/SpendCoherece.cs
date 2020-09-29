using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Logic.DatabaseContext;
using Api.Logic.Interface;
using AutoMapper;
using core_api.Logic.Interface;
using core_api.Logic.Model;
using Microsoft.EntityFrameworkCore;

namespace core_api.Logic.Repository
{
    public class SpendCoherece : ISpend
    {
        private readonly IMapper imapper;
        private readonly IApplicationUser iApplicationUser;
        private readonly FmContext context;
        private readonly string loggedInUser;
        public SpendCoherece(FmContext _context, IMapper _imapper, IApplicationUser _iApplicationUser)
        {
            context = _context;
            imapper = _imapper;
            iApplicationUser = _iApplicationUser;
            loggedInUser = iApplicationUser.GetUserId();
        }
        public async Task<Spend> CreateAsync(Spend tenet)
        {
            using (context)
            {
                tenet.CreatedBy = loggedInUser;
                context.Add(tenet);
                int isDone = await context.SaveChangesAsync();
                if (isDone > 0)
                    return tenet;
                else
                    return null;
            }
        }

        public async Task<bool> DeleteAsync(Spend tenet)
        {
            using (context)
            {
                tenet.IsActive = false;
                context.Entry(tenet).Property(x => x.IsActive).IsModified = true;
                int isDone = await context.SaveChangesAsync();
                if (isDone > 0)
                    return true;
                else
                    return false;
            }
        }

        public async Task<IList<Spend>> GetAllAsync()
        {
            using (context)
            {
                IQueryable<Spend> query = context.Spent.Where(x => x.IsActive == true && x.CreatedBy == loggedInUser);
                return await query.ToListAsync();
            }
        }

        public async Task<Spend> GetByIdAsync(Spend tenet)
        {
            using (context)
            {
                IQueryable<Spend> query = context.Spent.Where(x => x.IsActive == true && x.CreatedBy == loggedInUser && tenet.SpendId == tenet.SpendId);
                return await query.FirstOrDefaultAsync();
            }
        }

        public async Task<Spend> UpdateAsync(Spend tenet)
        {
            using (context)
            {
                tenet.CreateOn = DateTime.Now;
                context.Entry(tenet).Property(x => x.CategoryId).IsModified = true;
                context.Entry(tenet).Property(x => x.CreateOn).IsModified = true;
                context.Entry(tenet).Property(x => x.MoneySpent).IsModified = true;
                int isDone = await context.SaveChangesAsync();
                if (isDone > 0)
                    return tenet;
                else
                    return null;
            }
        }
    }
}