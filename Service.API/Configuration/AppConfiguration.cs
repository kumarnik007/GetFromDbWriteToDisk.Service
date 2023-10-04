using Service.API.Endpoints;

namespace Service.API.Configuration
{
    public class AppConfiguration
    {
        public static void AddEndpoints(WebApplication app, IConfiguration config)
        {
            Documents.Endpoints(app, config);
        }
    }
}
