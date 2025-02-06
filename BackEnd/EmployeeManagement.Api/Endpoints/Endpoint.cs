using EmployeeManagement.Api.Common.Api;
using EmployeeManagement.Api.Endpoints.Employees;
using EmployeeManagement.Api.Endpoints.Identity;
using EmployeeManagement.Api.Models;

namespace EmployeeManagement.Api.Endpoints
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app
                .MapGroup("");

            endpoints.MapGroup("/")
                .WithTags("Health Check")
                .MapGet("/", () => new { message = "OK" });

            endpoints.MapGroup("v1/employees")
                .WithTags("Employees")
                .RequireAuthorization()
                .MapEndpoint<CreateEmployeeEndpoint>()
                .MapEndpoint<UpdateEmployeeEndpoint>()
                .MapEndpoint<DeleteEmployeeEndpoint>()
                .MapEndpoint<GetEmployeeByIdEndpoint>()
                .MapEndpoint<GetAllEmployeesEndpoint>();            

            endpoints.MapGroup("v1/identity")
                .WithTags("Identity")
                .MapIdentityApi<User>();

            endpoints.MapGroup("v1/identity")
                .WithTags("Identity")
                .MapEndpoint<LogoutEndpoint>()
                .MapEndpoint<GetRolesEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}