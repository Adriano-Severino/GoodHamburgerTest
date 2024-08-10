using GoodHamburger.Api.Data;
using GoodHamburger.Api.Handlers;
using GoodHamburger.Api.Repository;
using GoodHamburger.Core;
using GoodHamburger.Core.Handlers;
using GoodHamburger.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GoodHamburger.Api
{
    /// <summary>
    /// Extensão de compilação
    /// </summary>
    public static class BuildExtension
    {
        /// <summary>
        /// Adiciona confiração a api
        /// </summary>
        /// <param name="builder"></param>
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            ApiConfiguration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackEndUrl") ?? string.Empty;
            Configuration.MobileName = builder.Configuration.GetValue<string>("MobileName") ?? string.Empty;
        }

        /// <summary>
        /// Adiciona Swagger para documentaçào 
        /// </summary>
        /// <param name="builder"></param>
        public static void AddDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Adiona o db context do entity framework
        /// </summary>
        /// <param name="builder"></param>
        public static void AddDataContexts(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(
                x => x.UseInMemoryDatabase(ApiConfiguration.ConnectionString));
        }

        /// <summary>
        /// Adiciona o cors
        /// </summary>
        /// <param name="builder"></param>
        public static void AddCrossOrigin(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(
                options => options.AddPolicy(
                    ApiConfiguration.CorsPolicyName,
                    policy => policy.WithOrigins([
                        Configuration.BackendUrl,
                    Configuration.MobileName,
                    ])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    ));
        }

        /// <summary>
        /// Adciona os serviços da api
        /// </summary>
        /// <param name="builder"></param>
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IOrderHandler, OrderHandler>();
            builder.Services.AddTransient<ISandwichHandler, SandwichHandler>();
            builder.Services.AddTransient<IExtraHandler, ExtraHandler>();
            builder.Services.AddTransient<IExtraRepository, ExtraRepository>();
            builder.Services.AddTransient<IOrderRepository, OrderRepository>();
            builder.Services.AddTransient<ISandwichRepository, SandwichRepository>();
        }
    }
}
