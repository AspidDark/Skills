using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skills.DataBase.DataAccess;
using Skills.DataBase.DataAccess.Services;

namespace Skills.DataBase
{
    public static class Entry
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("Skills.DataBase"));
            });

            services.AddScoped<ICahracterSkillsDataService, CahracterSkillsDataService>();
            services.AddScoped<ICharacterDataService, CharacterDataService>();
            services.AddScoped<ISkillDataService, SkillDataService>();

            return services;
        }
    }
}
