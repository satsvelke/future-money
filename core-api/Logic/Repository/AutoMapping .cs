using Api.Logic.Model;
using Api.Logic.ViewModel;
using AutoMapper;

namespace Api.Logic.Repository
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Bank, BankView>();
            CreateMap<BankView, Bank>();
        }
    }
}
