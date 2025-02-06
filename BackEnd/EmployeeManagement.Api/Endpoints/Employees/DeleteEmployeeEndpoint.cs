using EmployeeManagement.Api.Common.Api;
using EmployeeManagement.Core.Handlers;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Requests.Employee;
using EmployeeManagement.Core.Responses;
using System.Security.Claims;

namespace EmployeeManagement.Api.Endpoints.Employees
{
    public class DeleteEmployeeEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandleAsync)
                .WithName("Employees: Delete")
                .WithSummary("Delete an employee")
                .WithDescription("Delete an employee")
                .WithOrder(3)
                .Produces<Response<Employee?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IEmployeeHandler handler,
            long id)
        {
            var request = new DeleteEmployeeRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                Id = id
            };

            var result = await handler.DeleteAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}