using TestEMI.Application.DTO_s;
using TestEMI.Core.Models;

namespace TestEMI.Application.IServices
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();

        Task<Employee?> GetEmployeeById(int id);

        Task<IEnumerable<Employee>> GetAllEmployeesByDepartment(int departmentId);

        Task<Employee> CreateEmployee(EmployeeDto employee);

        Task<bool> UpdateEmployee(UpdateEmployeeDto employee);

        Task<bool> DeleteEmployee(int id);
    }
}
