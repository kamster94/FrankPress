using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace FrankPress.Web.Authentication
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAuth0Authentication(this IServiceCollection services, IConfiguration configuration)
        {
            string domain = configuration.GetSection("Auth0:Domain").Value;
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = domain;
                    options.Audience = configuration.GetSection("Auth0:Audience").Value;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("access:author", policy => policy.Requirements.Add(new HasScopeRequirement("access:author", domain)));
                options.AddPolicy("access:admin", policy => policy.Requirements.Add(new HasScopeRequirement("access:admin", domain)));
            });

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FrankPress API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                }); 
            });
        }
    }
}
