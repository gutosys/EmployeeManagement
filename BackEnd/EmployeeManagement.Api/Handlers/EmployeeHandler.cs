using EmployeeManagement.Api.Data;
using EmployeeManagement.Core.Handlers;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Requests.Employee;
using EmployeeManagement.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Handlers
{
    public class EmployeeHandler(AppDbContext context) : IEmployeeHandler
    {
        public async Task<Response<Employee?>> CreateAsync(CreateEmployeeRequest request)
        {
            try
            {
                List<PhoneNumber> phoneNumbers = new List<PhoneNumber>();
                foreach (var item in request.PhoneNumbers)
                {
                    phoneNumbers.Add(new PhoneNumber() { Number = item.Number });
                }
                
                var employee = new Employee
                {
                    UserId = request.UserId,
                    Name = request.Name,
                    LastName = request.LastName,
                    Email = request.Email,
                    DocumentId = request.DocumentId,

                    
                    PhoneNumbers = phoneNumbers,

                    DateOfBirth = request.DateOfBirth,
                    EEmployeeType = request.EEmployeeType,
                    Password = request.Password
                };

                await context.Employees.AddAsync(employee);
                await context.SaveChangesAsync();

                foreach (var phoneNumber in request.PhoneNumbers)
                {
                    var phone = new PhoneNumber
                    {
                        Number = phoneNumber.Number,
                        EmployeeId = employee.Id
                    };

                    await context.PhoneNumbers.AddAsync(phone);
                }

                await context.SaveChangesAsync();


                return new Response<Employee?>(employee, 201, "Employee created successfully!");
            }
            catch
            {
                return new Response<Employee?>(null, 500, "Unable to create an employee");
            }
        }

        public async Task<Response<Employee?>> UpdateAsync(UpdateEmployeeRequest request)
        {
            try
            {
                var employee = await context
                    .Employees
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (employee is null)
                    return new Response<Employee?>(null, 404, "Employee not found");


                employee.UserId = request.UserId;
                employee.Name = request.Name;
                employee.LastName = request.LastName;
                employee.Email = request.Email;
                employee.DocumentId = request.DocumentId;

                employee.DateOfBirth = request.DateOfBirth;
                employee.EEmployeeType = request.EEmployeeType;
                employee.Password = request.Password;

                context.Employees.Update(employee);
                await context.SaveChangesAsync();

                return new Response<Employee?>(employee, message: "Employee successfully updated");
            }
            catch
            {
                return new Response<Employee?>(null, 500, "Unable to update an employee");
            }
        }

        public async Task<Response<Employee?>> DeleteAsync(DeleteEmployeeRequest request)
        {
            try
            {
                var employee = await context
                    .Employees
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (employee is null)
                    return new Response<Employee?>(null, 404, "Employee not found");

                context.Employees.Remove(employee);
                await context.SaveChangesAsync();

                return new Response<Employee?>(employee, message: "Employee successfully deleted!");
            }
            catch
            {
                return new Response<Employee?>(null, 500, "Unable to delete an employee");
            }
        }

        public async Task<Response<Employee?>> GetByIdAsync(GetEmployeeByIdRequest request)
        {
            try
            {
                var employee = await context
                    .Employees
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                return employee is null
                    ? new Response<Employee?>(null, 404, "Employee not found")
                    : new Response<Employee?>(employee);
            }
            catch
            {
                return new Response<Employee?>(null, 500, "Unable to retrieve an employee");
            }
        }

        public async Task<PagedResponse<List<Employee>>> GetAllAsync(GetAllEmployeesRequest request)
        {
            try
            {
                var query = context
                    .Employees
                    .AsNoTracking()
                    .Where(x => x.UserId == request.UserId)
                    .OrderBy(x => x.Name);

                var employees = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Employee>>(
                    employees,
                    count,
                    request.PageNumber,
                    request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Employee>>(null, 500, "Unable to consult employees");
            }
        }
    }
}
