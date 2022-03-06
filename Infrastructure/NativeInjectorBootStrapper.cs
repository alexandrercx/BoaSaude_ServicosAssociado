using Application.Interface;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application
            services.AddScoped<IServicosAssociadoAppService, ServicosAssociadoAppService>();
            services.AddScoped<IAgendamentoAppService, AgendamentoAppService>();

            //Infra
            services.AddScoped(typeof(IServGenerics<>), typeof(RepositoryGenerics<>));
            services.AddScoped<IServAgendamento, RepositoryAgendamento>();
            services.AddScoped<IServAssociado, RepositoryAssociado>();
            services.AddScoped<IServConveniado, RepositoryConveniado>();
            services.AddScoped<IServEndereco, RepositoryEndereco>();
            services.AddScoped<IServConveniado, RepositoryConveniado>();
            services.AddScoped<IServTipoAtendimento, RepositoryTipoAtendimento>();
        }
    }
}
