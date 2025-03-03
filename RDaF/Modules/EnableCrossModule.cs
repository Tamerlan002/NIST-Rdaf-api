namespace RDaF.Api.Modules
{
    public class EnableCrossModule
    {
        public static void Load(IServiceCollection services, string name)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name, builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }
    }
}
