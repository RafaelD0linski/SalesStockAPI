using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SalesStock.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SalesStock API",
                    Version = "v1",
                    Description = "API para controle de vendas e estoque. Desenvolvida em C# (.NET 8) por Rafael Dolinski.",
                    Contact = new OpenApiContact
                    {
                        Name = "Rafael Dolinski",
                        Email = "rafaeldolinski14@gmail.com",
                        Url = new Uri("https://github.com/RafaelD0linski")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });

                // Ativar suporte a comentários XML (se quiser gerar documentação dos endpoints)
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }

                // (Opcional) Se depois quiser colocar autenticação JWT
                // c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                // {
                //     Description = "Insira o token JWT: Bearer {seu_token}",
                //     Name = "Authorization",
                //     In = ParameterLocation.Header,
                //     Type = SecuritySchemeType.ApiKey
                // });
                //
                // c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                //     {
                //         new OpenApiSecurityScheme {
                //             Reference = new OpenApiReference {
                //                 Type = ReferenceType.SecurityScheme,
                //                 Id = "Bearer"
                //             }
                //         },
                //         new string[] {}
                //     }
                // });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SalesStock API v1");
                c.RoutePrefix = string.Empty; // deixa o Swagger na rota raiz (http://localhost:5000/)
            });

            return app;
        }
    }
}
