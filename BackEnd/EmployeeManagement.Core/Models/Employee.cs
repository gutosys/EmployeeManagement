using EmployeeManagement.Core.Enums;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace EmployeeManagement.Core.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string DocumentId { get; set; } = string.Empty;
        public ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();     
        public DateTime DateOfBirth { get; set; }
        public EEmployeeType EEmployeeType { get; set; }
        public string Password { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;
    }
}
