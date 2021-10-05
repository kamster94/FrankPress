using FrankPress.Domain.Abstractions;
using FrankPress.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FrankPress.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceCollectionExtensions));

            services.AddScoped<IIdentityProviderService, IdentityProviderService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
