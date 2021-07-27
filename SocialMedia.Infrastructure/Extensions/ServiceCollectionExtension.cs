using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Services;
using SocialMedia.Infrastructure.Data;
using SocialMedia.Infrastructure.Interfaces;
using SocialMedia.Infrastructure.Options;
using SocialMedia.Infrastructure.Repositories;
using SocialMedia.Infrastructure.Services;
using System.Text;

namespace SocialMedia.Infrastructure.Extensions
{
    // It doesn't need to be instantiated because it's static
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SocialMediaContext>(options => options.UseSqlServer(configuration.GetConnectionString("SocialMedia")));
            
            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            // Default Pagination Options
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            // Hash Password Options
            services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IPasswordHasher, PasswordService>();

            services.AddSingleton<IUriService>(provider =>
            {
                var accessor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });

            return services;
        }
    }
}
