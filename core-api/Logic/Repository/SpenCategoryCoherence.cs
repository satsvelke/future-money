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
    public class SpenCategoryCoherence : ISpendCategory
    {

        private readonly IMapper imapper;
        private readonly IApplicationUser iApplicationUser;
        private readonly FmContext context;
        private readonly string loggedInUser;
        public SpenCategoryCoherence(FmContext _context, IMapper _imapper, IApplicationUser _iApplicationUser)
        {
            context = _context;
            imapper = _imapper;
            iApplicationUser = _iApplicationUser;
            loggedInUser = iApplicationUser.GetUserId();
        }
        public async Task<SpendCategory> CreateAsync(SpendCategory tenet)
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

        public async Task<bool> DeleteAsync(SpendCategory tenet)
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

        public async Task<IList<SpendCategory>> GetAllAsync()
        {
            using (context)
            {
                IQueryable<SpendCategory> query = context.SpendCategories.Where(x => x.IsActive == true && x.CreatedBy == loggedInUser);
                return await query.ToListAsync();
            }
        }

        public async Task<SpendCategory> GetByIdAsync(SpendCategory tenet)
        {
            using (context)
            {
                IQueryable<SpendCategory> query = context.SpendCategories.Where(x => x.IsActive == true && x.CategoryId == tenet.CategoryId && x.CreatedBy == loggedInUser);
                return await query.FirstOrDefaultAsync();
            }
        }

        public async Task<SpendCategory> UpdateAsync(SpendCategory tenet)
        {
            using (context)
            {
                tenet.CreatedBy = loggedInUser;
                context.Update(tenet);
                int isDone = await context.SaveChangesAsync();
                if (isDone > 0)
                    return tenet;
                else
                    return null;
            }
        }
    }
}