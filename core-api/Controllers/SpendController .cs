using System.Threading.Tasks;
using Api.Controllers;
using core_api.Logic.Interface;
using core_api.Logic.Model;
using Microsoft.AspNetCore.Mvc;

namespace core_api.Controllers
{
    public class SpendController : FmController
    {
        private readonly ISpend ISpend;
        public SpendController(ISpend _ISpend) => ISpend = _ISpend;

        [HttpPost]
        public async Task<IActionResult> Create(Spend tenet) => Ok(await ISpend.CreateAsync(tenet));

        [HttpPost]
        public async Task<IActionResult> Delete(Spend tenet) => Ok(await ISpend.DeleteAsync(tenet));

        [HttpPost]
        public async Task<IActionResult> Update(Spend tenet) => Ok(await ISpend.UpdateAsync(tenet));

        [HttpGet]
        public async Task<IActionResult> GetCategory(Spend tenet) => Ok(await ISpend.GetByIdAsync(tenet));

        [HttpGet]
        public async Task<IActionResult> GetCategories(Spend tenet) => Ok(await ISpend.GetAllAsync());

    }
}