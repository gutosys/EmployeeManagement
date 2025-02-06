using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Requests.Employee;
using EmployeeManagement.Core.Responses;

namespace EmployeeManagement.Core.Handlers
{
    public interface IEmployeeHandler
    {
        Task<Response<Employee?>> CreateAsync(CreateEmployeeRequest request);
        Task<Response<Employee?>> UpdateAsync(UpdateEmployeeRequest request);
        Task<Response<Employee?>> DeleteAsync(DeleteEmployeeRequest request);
        Task<Response<Employee?>> GetByIdAsync(GetEmployeeByIdRequest request);
        Task<PagedResponse<List<Employee>>> GetAllAsync(GetAllEmployeesRequest request);
    }
}
