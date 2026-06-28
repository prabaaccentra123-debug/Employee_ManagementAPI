using EmployeeManagement.Interfaces;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositary
{
    public class EmployeeRepositary : IEmployeeRepositary
    {
        private readonly EmployeeDbContext _employeeDbContext;        


        public EmployeeRepositary(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;            

        }

        //To get a list of employees
        public async Task<List<Employee>> GetEmployees(CancellationToken cancellationToken)
        {
            return await _employeeDbContext.Employees.ToListAsync(cancellationToken);
        }

        public async Task<Employee> GetEmployee(int id ,CancellationToken cancellationToken)

        {
             return await _employeeDbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id, cancellationToken);
        }

        public async Task<Employee> AddEmployee(Employee employee, CancellationToken cancellationToken)
        {
            _employeeDbContext.Employees.AddAsync(employee, cancellationToken);

            await _employeeDbContext.SaveChangesAsync(cancellationToken);

            return employee;
        }

        public async Task UpdateEmployee(Employee employee, CancellationToken cancellationToken)
        {
            _employeeDbContext.Employees.Update(employee);

            await _employeeDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteEmployee(int id, CancellationToken cancellationToken)
        {
            var employee = await GetEmployee(id,cancellationToken);

            if (employee == null)
                throw new Exception("Employee not found");

            _employeeDbContext.Employees.Remove(employee);

            await _employeeDbContext.SaveChangesAsync(cancellationToken);
        }

    }
}
