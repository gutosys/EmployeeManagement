﻿using EmployeeManagement.Api.Data;
using EmployeeManagement.Api.Handlers;
using EmployeeManagement.Api.Models;
using EmployeeManagement.Core;
using EmployeeManagement.Core.Handlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Common.Api
{
    public static class BuilderExtension
    {
        public static void AddConfiguration(
            this WebApplicationBuilder builder)
        {
            Configuration.ConnectionString =
                builder
                    .Configuration
                    .GetConnectionString("DefaultConnection")
                ?? string.Empty;
            Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
            Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;            
        }

        public static void AddDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddOpenApi();
        }

        public static void AddSecurity(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddIdentityCookies();

            builder.Services.AddAuthorization();
        }

        public static void AddDataContexts(this WebApplicationBuilder builder)
        {
            builder
                .Services
                .AddDbContext<AppDbContext>(
                    x => { x.UseSqlServer(Configuration.ConnectionString); });
            builder.Services
                .AddIdentityCore<User>()
                .AddRoles<IdentityRole<long>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddApiEndpoints();
        }

        public static void AddCrossOrigin(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(
                options => options.AddPolicy(
                    ApiConfiguration.CorsPolicyName,
                    policy => policy
                        .WithOrigins([
                            Configuration.BackendUrl,
                        Configuration.FrontendUrl
                        ])
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                ));
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder
            .Services
                .AddTransient<IEmployeeHandler, EmployeeHandler>();
        }
    }
}