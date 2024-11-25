using TestEMI.Application.DTO_s;
using TestEMI.Application.IServices;
using TestEMI.Core.Interfaces;
using TestEMI.Core.Models;

namespace TestEMI.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        public readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> CreateEmployee(EmployeeDto employee)
        {
            employee.BonusCalculator = employee.CurrentPosition == 1 ? new RegularEmployeeBonusCalculator() : new ManagerBonusCalculator();
            employee.CalculateYearlyBonus();
            return await _employeeRepository.CreateEmployee(employee.ConvertToDomain());
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var entity = await GetEmployeeById(id);
            if (entity == null)
            {
                return false;
            }

            await _employeeRepository.DeleteEmployee(entity);
            return true;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _employeeRepository.GetAllEmployees();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesByDepartment(int departmentId)
        {
            return await _employeeRepository.GetAllEmployeesByDepartment(departmentId);
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await _employeeRepository.GetEmployeeById(id);
        }

        public async Task<bool> UpdateEmployee(UpdateEmployeeDto employee)
        {
            var entity = await GetEmployeeById(employee.Id);
            if (entity == null)
            {
                return false;
            }

            entity.Name = employee.Name;
            entity.PositionId = employee.CurrentPosition;
            entity.Salary = employee.Salary;

            await _employeeRepository.UpdateEmployee(entity);
            return true;
        }
    }
}
