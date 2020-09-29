using System.Threading.Tasks;
using Api.Logic.Interface;
using Api.Logic.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BankController : FmController
    {
        private readonly IBank bankCoherence;
        public BankController(IBank _bankCoherence) => bankCoherence = _bankCoherence;

        [HttpPost]
        public async Task<IActionResult> Create(BankView bank) => Ok(await bankCoherence.CreateAsync(bank));

        [HttpPost]
        public async Task<IActionResult> Delete(BankView bank) => Ok(await bankCoherence.DeleteAsync(bank));

        [HttpPost]
        public async Task<IActionResult> Update(BankView bank) => Ok(await bankCoherence.UpdateAsync(bank));

        [HttpGet]
        public async Task<IActionResult> GetBank(BankView bank) => Ok(await bankCoherence.GetByIdAsync(bank));

        [HttpGet]
        public async Task<IActionResult> GetBanks() => Ok(await bankCoherence.GetAllAsync());
    }
}
