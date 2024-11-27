using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCondo.Application.Services.BlocoService;
using MyCondo.Application.Services.BlocoService.Interface;
using MyCondo.Application.Services.CondominioService;
using MyCondo.Application.Services.CondominioService.Interface;
using MyCondo.Domain.Interface.Base;
using MyCondo.Domain.Interface.Bloco;
using MyCondo.Domain.Interface.Condominio;
using MyCondo.Domain.Transfer.DataTransfer.Bloco.Profiles;
using MyCondo.Domain.Transfer.DataTransfer.Condominio.Profiles;
using MyCondo.Infra.Data;
using MyCondo.Infra.Mappings.Bloco.Validator;
using MyCondo.Infra.Mappings.Condominio.Validator;
using MyCondo.Infra.Repositories.Base;
using MyCondo.Infra.Repositories.Bloco;
using MyCondo.Infra.Repositories.Condominio;

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
        ConfiguraServices(services);
        ConfiguraFLuentValidation(services);

        return services;
    }

    private static void ConfigurarAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(CondominiosProfile));
        services.AddAutoMapper(typeof(BlocosProfile));
    }

    private static void ConfiguraServices(IServiceCollection services)
    {
        services.AddScoped<ICondominiosService, CondominiosService>();
        services.AddScoped<IBlocosService, BlocosService>();
    }

    private static void ConfiguraRepositories(IServiceCollection services)
    {
        services.AddScoped<ICondominiosRepository, CondominiosRepository>();
        services.AddScoped<IBlocosRepository, BlocoRepository>();
    }

    private static void ConfiguraFLuentValidation(IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CondominiosValidator>();
        services.AddValidatorsFromAssemblyContaining<BlocosValidator>();
    }
}
