using EmployeeManagement.Models;

namespace EmployeeManagement.Interfaces
{
    public interface IEmployeeRepositary
    {
        Task<List<Employee>> GetEmployees(CancellationToken cancellationToken);
        Task<Employee> GetEmployee(int id, CancellationToken cancellationToken);
        Task<Employee> AddEmployee(Employee employee, CancellationToken cancellationToken);
        Task UpdateEmployee(Employee employee, CancellationToken cancellationToken);
        Task DeleteEmployee(int id, CancellationToken cancellationToken);


    }
}
