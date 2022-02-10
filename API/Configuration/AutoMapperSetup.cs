using Application.AutoMapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.Configuration
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection service)
        {
           if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            service.AddAutoMapper(typeof(ViewModelToDomainMapping), typeof(DomainToViewModelMapping));
           

        }
    }
}
