using Microsoft.EntityFrameworkCore;
using TestEMI.Core.Interfaces;
using TestEMI.Core.Models;
using TestEMI.Infrastructure.Data;

namespace TestEMI.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task DeleteEmployee(Employee employee)
        {            
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();         
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesByDepartment(int departmentId)
        {
            return await _context.Employees
                         .Where(e => e.DepartmentId == departmentId && e.Projects.Any())
                         .ToListAsync();
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateEmployee(Employee employee)
        {                        
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
