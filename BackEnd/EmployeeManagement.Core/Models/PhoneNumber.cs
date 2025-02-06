namespace EmployeeManagement.Core.Models
{
    public class PhoneNumber
    {
        public long Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public long EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}
