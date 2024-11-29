using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCondo.Application.Services.ApartamentoService;
using MyCondo.Application.Services.ApartamentoService.Interface;
using MyCondo.Application.Services.Base;
using MyCondo.Application.Services.BlocoService;
using MyCondo.Application.Services.BlocoService.Interface;
using MyCondo.Application.Services.CondominioService;
using MyCondo.Application.Services.CondominioService.Interface;
using MyCondo.Application.Services.MoradorService;
using MyCondo.Application.Services.MoradorService.Interface;
using MyCondo.Domain.Interface.Apartamento;
using MyCondo.Domain.Interface.Base;
using MyCondo.Domain.Interface.Bloco;
using MyCondo.Domain.Interface.Condominio;
using MyCondo.Domain.Interface.Morador;
using MyCondo.Domain.Transfer.DataTransfer.Apartamento.Profiles;
using MyCondo.Domain.Transfer.DataTransfer.Apartamento.Request;
using MyCondo.Domain.Transfer.DataTransfer.Apartamento.Response;
using MyCondo.Domain.Transfer.DataTransfer.Bloco.Profiles;
using MyCondo.Domain.Transfer.DataTransfer.Bloco.Request;
using MyCondo.Domain.Transfer.DataTransfer.Bloco.Response;
using MyCondo.Domain.Transfer.DataTransfer.Condominio.Profiles;
using MyCondo.Domain.Transfer.DataTransfer.Condominio.Request;
using MyCondo.Domain.Transfer.DataTransfer.Condominio.Response;
using MyCondo.Domain.Transfer.DataTransfer.Morador.Profiles;
using MyCondo.Domain.Transfer.DataTransfer.Morador.Request;
using MyCondo.Domain.Transfer.DataTransfer.Morador.Response;
using MyCondo.Infra.Data;
using MyCondo.Infra.Mappings.Apartamento.Validator;
using MyCondo.Infra.Mappings.Bloco.Validator;
using MyCondo.Infra.Mappings.Condominio.Validator;
using MyCondo.Infra.Mappings.Morador.Validator;
using MyCondo.Infra.Repositories.Apartamento;
using MyCondo.Infra.Repositories.Base;
using MyCondo.Infra.Repositories.Bloco;
using MyCondo.Infra.Repositories.Condominio;
using MyCondo.Infra.Repositories.Morador;

namespace MyCondo.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MyCondoContext>(options =>
            options.UseSqlite(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("MyCondo.API")));

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        ConfigurarAutoMapper(services);
        ConfiguraRepositories(services);
        ConfigureBaseService(services);
        ConfiguraServices(services);
        ConfiguraFLuentValidation(services);

        return services;
    }

    private static void ConfigurarAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(CondominiosProfile));
        services.AddAutoMapper(typeof(BlocosProfile));
        services.AddAutoMapper(typeof(ApartamentoProfile));
        services.AddAutoMapper(typeof(MoradoresProfile));
    }

    private static void ConfiguraServices(IServiceCollection services)
    {
        
        services.AddScoped<ICondominiosService, CondominiosService>();
        services.AddScoped<IBlocosService, BlocosService>();
        services.AddScoped<IApartamentosService, ApartamentosService>();
        services.AddScoped<IMoradoresService, MoradoresService>();
    }

    private static void ConfigureBaseService(IServiceCollection services)
    {
        services.AddScoped<IBaseService<MoradoresPesquisaRequest, MoradoresInserirRequest, MoradoresAtualizarRequest, MoradoresExcluirRequest, MoradoresResponse>, MoradoresService>();
        services.AddScoped<IBaseService<BlocosPesquisaRequest, BlocosInserirRequest, BlocosAtualizarRequest, BlocosExcluirRequest, BlocosResponse>, BlocosService>();
        services.AddScoped<IBaseService<ApartamentosPesquisaRequest, ApartamentosInserirRequest, ApartamentosAtualizarRequest, ApartamentosExcluirRequest, ApartamentosResponse>, ApartamentosService>();
        services.AddScoped<IBaseService<CondominiosPesquisaRequest, CondominiosInserirRequest, CondominiosAtualizarRequest, CondominiosExcluirRequest, CondominiosResponse>, CondominiosService>();
    }

    private static void ConfiguraRepositories(IServiceCollection services)
    {
        services.AddScoped<ICondominiosRepository, CondominiosRepository>();
        services.AddScoped<IBlocosRepository, BlocoRepository>();
        services.AddScoped<IApartamentosRepository, ApartamentosRepository>();
        services.AddScoped<IMoradoresRepository, MoradoresRepository>();
    }

    private static void ConfiguraFLuentValidation(IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CondominiosValidator>();
        services.AddValidatorsFromAssemblyContaining<BlocosValidator>();
        services.AddValidatorsFromAssemblyContaining<ApartamentosValidator>();
        services.AddValidatorsFromAssemblyContaining<MoradoresValidator>();
    }
}
