using TestEMI.Core.Models;

namespace TestEMI.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();

        Task<Employee?> GetEmployeeById(int id);

        Task<Employee> CreateEmployee(Employee employee);

        Task UpdateEmployee(Employee employee);

        Task DeleteEmployee(Employee employee);

        Task<IEnumerable<Employee>> GetAllEmployeesByDepartment(int departmentId);
    }
}
