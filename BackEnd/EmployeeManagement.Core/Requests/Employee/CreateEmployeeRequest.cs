using EmployeeManagement.Core.Enums;
using EmployeeManagement.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Core.Requests.Employee
{
    public class CreateEmployeeRequest : Request
    {
        [Required(ErrorMessage = "Invalid Name")]
        [MaxLength(300, ErrorMessage = "The name must contain up to 300 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Invalid LastName")]
        [MaxLength(300, ErrorMessage = "The lastName must contain up to 300 characters")]
        public string LastName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Invalid Email")]
        [MaxLength(300, ErrorMessage = "The email must contain up to 300 characters")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Invalid DocumentId")]
        [MaxLength(300, ErrorMessage = "The documentId must contain up to 300 characters")]
        public string DocumentId { get; set; } = string.Empty;

        public ICollection<CreatePhoneNumberRequest> PhoneNumbers { get; set; } = new List<CreatePhoneNumberRequest>();

        [Required(ErrorMessage = "Invalid DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Invalid EEmployeeType")]
        public EEmployeeType EEmployeeType { get; set; }

        [Required(ErrorMessage = "Invalid Password")]
        [MaxLength(300, ErrorMessage = "The password must contain up to 300 characters")]
        public string Password { get; set; } = string.Empty;
    }

    public class CreatePhoneNumberRequest: Request
    {
        [Required(ErrorMessage = "Invalid Phone Number")]
        [MaxLength(30, ErrorMessage = "The phone number must contain up to 30 characters")]
        public string Number { get; set; } = string.Empty;
    }
}