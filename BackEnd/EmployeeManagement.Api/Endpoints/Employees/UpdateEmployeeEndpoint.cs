using EmployeeManagement.Api.Common.Api;
using EmployeeManagement.Core.Handlers;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Requests.Employee;
using EmployeeManagement.Core.Responses;
using System.Security.Claims;

namespace EmployeeManagement.Api.Endpoints.Employees
{
    public class UpdateEmployeeEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{id}", HandleAsync)
                .WithName("Employees: Update")
                .WithSummary("Update an employee")
                .WithDescription("Update an employee")
                .WithOrder(2)
                .Produces<Response<Employee?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IEmployeeHandler handler,
            UpdateEmployeeRequest request,
            long id)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            request.Id = id;

            var result = await handler.UpdateAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}