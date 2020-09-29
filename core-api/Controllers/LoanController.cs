using System.Threading.Tasks;
using Api.Controllers;
using Api.Logic.Model;
using core_api.Logic.Interface;
using Microsoft.AspNetCore.Mvc;

namespace core_api.Controllers
{
    public class LoanController : FmController
    {
        private readonly ILoan ILoan;
        public LoanController(ILoan _ILoan) => ILoan = _ILoan;

        [HttpPost]
        public async Task<IActionResult> Create(Loan loan) => Ok(await ILoan.CreateAsync(loan));

        [HttpPost]
        public async Task<IActionResult> Delete(Loan loan) => Ok(await ILoan.DeleteAsync(loan));

        [HttpPost]
        public async Task<IActionResult> Update(Loan loan) => Ok(await ILoan.UpdateAsync(loan));

        [HttpGet]
        public async Task<IActionResult> GetLoan(Loan loan) => Ok(await ILoan.GetByIdAsync(loan));

        [HttpGet]
        public async Task<IActionResult> GetLoans() => Ok(await ILoan.GetAllAsync());
    }
}