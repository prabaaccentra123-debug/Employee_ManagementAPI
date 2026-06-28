namespace EmployeeManagement.Dto
{
    public class EmployeeResponseDto
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Department { get; set; } = null!;

        public DateTime DateOfJoining { get; set; }
    }
}
