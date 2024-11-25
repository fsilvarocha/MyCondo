using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCondo.Domain.Interface.Base;
using MyCondo.Infra.Data;
using MyCondo.Infra.Repositories.Base;

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
        //services.AddAutoMapper(typeof(ProdutosProfile));
    }

    private static void ConfiguraServices(IServiceCollection services)
    {

    }

    private static void ConfiguraRepositories(IServiceCollection services)
    {

    }

    private static void ConfiguraFLuentValidation(IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        // services.AddValidatorsFromAssemblyContaining<ProdutosValidator>();
    }
}
