using Api.Logic.Interface;
using Api.Logic.Repository;
using core_api.Logic.Interface;
using core_api.Logic.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Logic.Dependency
{
    public static class Injection
    {
        public static void GetDependency(this IServiceCollection service)
        {
            service.AddScoped<IBank, BankCoherence>();
            service.AddScoped<ILoan, LoanCoherence>();
            service.AddScoped<ILoanPaymentHistory, LoanPaymentHistoryCoherence>();
        }
    }
}
