using EmployeeManagement.Api.Common.Api;
using EmployeeManagement.Core.Handlers;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Requests.Employee;
using EmployeeManagement.Core.Responses;
using System.Security.Claims;

namespace EmployeeManagement.Api.Endpoints.Employees
{
    public class GetEmployeeByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandleAsync)
                .WithName("Employees: Get By Id")
                .WithSummary("Retrieve an employee")
                .WithDescription("Retrieve an employee")
                .WithOrder(4)
                .Produces<Response<Employee?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IEmployeeHandler handler,
            long id)
        {
            var request = new GetEmployeeByIdRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                Id = id
            };

            var result = await handler.GetByIdAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}