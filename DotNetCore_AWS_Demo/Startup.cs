using DotNetCore_AWS_Demo.Interface;
using DotNetCore_AWS_Demo.Services;

namespace DotNetCore_AWS_Demo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAppConfiguration, AppConfiguration>();
            
        }
    }
}
