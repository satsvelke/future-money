using System.Threading.Tasks;
using Api.Controllers;
using core_api.Logic.Interface;
using core_api.Logic.Model;
using Microsoft.AspNetCore.Mvc;

namespace core_api.Controllers
{
    public class SpendCategoryController : FmController
    {
        private readonly ISpendCategory ISpendCategory;
        public SpendCategoryController(ISpendCategory _ISpendCategory) => ISpendCategory = _ISpendCategory;

        [HttpPost]
        public async Task<IActionResult> Create(SpendCategory tenet) => Ok(await ISpendCategory.CreateAsync(tenet));

        [HttpPost]
        public async Task<IActionResult> Delete(SpendCategory tenet) => Ok(await ISpendCategory.DeleteAsync(tenet));

        [HttpPost]
        public async Task<IActionResult> Update(SpendCategory tenet) => Ok(await ISpendCategory.UpdateAsync(tenet));

        [HttpGet]
        public async Task<IActionResult> GetCategory(SpendCategory tenet) => Ok(await ISpendCategory.GetByIdAsync(tenet));

        [HttpGet]
        public async Task<IActionResult> GetCategories(SpendCategory tenet) => Ok(await ISpendCategory.GetAllAsync());
    }
}