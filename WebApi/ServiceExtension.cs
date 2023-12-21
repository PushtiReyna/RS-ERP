using BusinessLayer;
using ServiceLayer;
using ServiceLayer.CommonHelpers;

namespace WebApi
{
    public static class ServiceExtension
    {
        public static void DIScope(this IServiceCollection service)
        {
            service.AddScoped<CommonHelper>();

            service.AddScoped<CommonRepo>();
            service.AddScoped<AuthHelper>();

            service.AddScoped<IAuth, AuthImpl>();
            service.AddScoped<AuthBLL>();

        }
    }
}
