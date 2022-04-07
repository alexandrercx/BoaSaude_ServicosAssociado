using Application.ViewModel.Request;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<RequestAgendamentoViewModel, Agendamento>();
        }
    }
}
