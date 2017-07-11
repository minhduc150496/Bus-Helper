using System.Web.Http;
using WebActivatorEx;
using BusHelperAPI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace BusHelperAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                    .EnableSwagger(c => c.SingleApiVersion("v1", "Bus Helper API"))
                    .EnableSwaggerUi();
        }
    }
}
