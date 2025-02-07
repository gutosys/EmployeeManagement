using EmployeeManagement.Api.Common.Api;
using EmployeeManagement.Core.Handlers;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Requests.Employee;
using EmployeeManagement.Core.Responses;
using FluentValidation;
using System.Security.Claims;

namespace EmployeeManagement.Api.Endpoints.Employees
{
    public class CreateEmployeeEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
                .WithName("Employees: Create")
                .WithSummary("Create a new employee")
                .WithDescription("Create a new employee")
                .WithOrder(1)
                .Produces<Response<Employee?>>();

        public static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IEmployeeHandler handler,
            CreateEmployeeRequest request, IValidator<CreateEmployeeRequest> validator)
        {
            //Utilização de FluentValidation
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid) 
            {
                var validation = new HttpValidationProblemDetails(validationResult.ToDictionary());
                return TypedResults.BadRequest(validation);
            }

            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.CreateAsync(request);
            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result.Data);
        }
    }
}