using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.Configuration;

namespace TasleemDelivery
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = GoogleDefaults.AuthenticationScheme;
            })
             .AddGoogle(options =>
            {
                 options.ClientId = _configuration["Authentication:Google:ClientId"];
                 options.ClientSecret = _configuration["Authentication:Google:ClientSecret"];
             });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Other middleware...

            app.UseAuthentication();
            app.UseAuthorization();

            // Other middleware...
        }
    }
}
