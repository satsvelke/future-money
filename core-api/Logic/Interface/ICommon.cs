using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Logic.Interface
{
    public interface ICommon<Tenet> where Tenet : class
    {
        Task<Tenet> CreateAsync(Tenet tenet);
        Task<Tenet> UpdateAsync(Tenet tenet);
        Task<bool> DeleteAsync(Tenet tenet);
        Task<IList<Tenet>> GetAllAsync();
        Task<Tenet> GetByIdAsync(Tenet tenet);
    }
}
