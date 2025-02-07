using EmployeeManagement.Api.Validators;
using EmployeeManagement.Core.Requests.Employee;

namespace EmployeeManagement.Test
{
    public class EmployeeTest
    {
        [Fact]
        public void VadlidateCreateEmployee()
        {
            var request  = Build();
            var validator = new CreateEmployeeValidator();

            var result = validator.Validate(request);

            Assert.True(!result.IsValid);
            Assert.True(result.Errors.Count() == 1);
        }

        public CreateEmployeeRequest Build()
        {
            return new CreateEmployeeRequest() 
            {
                Email = "formatoincorreto"
            };
        }
    }
}
