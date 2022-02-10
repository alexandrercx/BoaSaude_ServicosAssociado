using Application.ViewModel.Request;
using Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Application.AutoMapper
{
    public class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<PostServicosAssociadoViewModel, PostServicosAssociadoModel>();
        }
    }
}
