using Application.Interface;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application
            services.AddScoped<IServicosAssociadoAppService, ServicosAssociadoAppService>();

            //Infra
            services.AddScoped<IServicosAssociadoRepository, ServicosAssociadoRepository>();
        }
    }
}
