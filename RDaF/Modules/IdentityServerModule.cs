using Microsoft.AspNetCore.Identity;

namespace RDaF.Api.Modules
{
    public class IdentityServerModule
    {

        public static void Load(IServiceCollection services)
        {
            services.AddControllers();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 0;

            });
        }
    }
}
