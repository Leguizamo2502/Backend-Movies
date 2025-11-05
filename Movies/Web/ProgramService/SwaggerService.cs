using Entity.Domain.Enums;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Web.ProgramService
{
    public static class SwaggerService
    {
        public static IServiceCollection AddSwaggerWithJwt(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v2" });

                // Config swagger Enum Deletes

                c.MapType<DeleteType>(() => new OpenApiSchema
                {
                    Type = "string",
                    Enum = Enum.GetNames(typeof(DeleteType))
               .Select(name => new OpenApiString(name) as IOpenApiAny)
               .ToList()
                });

                c.MapType<GetAllType>(() => new OpenApiSchema
                {
                    Type = "string",
                    Enum = Enum.GetNames(typeof(GetAllType))
              .Select(name => new OpenApiString(name) as IOpenApiAny)
              .ToList()
                });




                c.AddSecurityDefinition("DbProvider", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "X-DB-Provider",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Select DB Provider: sqlserver, postgres, mysql"
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Name = "X-DB-Provider",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "DbProvider"
                }
            },
            new List<string>()
        }
    });


            });

            return services;
        }
    }
}
