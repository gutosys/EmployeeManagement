using EmployeeManagement.Api.Common.Api;
using EmployeeManagement.Core;
using EmployeeManagement.Core.Handlers;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Requests.Employee;
using EmployeeManagement.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeManagement.Api.Endpoints.Employees
{
    public class GetAllEmployeesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
                .WithName("Employees: Get All")
                .WithSummary("Recovers all employees")
                .WithDescription("Recovers all employees")
                .WithOrder(5)
                .Produces<PagedResponse<List<Employee>?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IEmployeeHandler handler,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllEmployeesRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                PageNumber = pageNumber,
                PageSize = pageSize,
            };

            var result = await handler.GetAllAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}