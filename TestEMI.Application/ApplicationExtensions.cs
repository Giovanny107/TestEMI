using TestEMI.Application.DTO_s;
using TestEMI.Core.Models;

namespace TestEMI.Application
{
    public static class ApplicationExtensions
    {
        public static Employee ConvertToDomain(this EmployeeDto employeeDto)
        {
            return new Employee
            {
                Name = employeeDto.Name,
                PositionId = employeeDto.CurrentPosition,
                Salary = employeeDto.Salary,
                DepartmentId = employeeDto.DepartmentId
            };
        }

        public static User ConvertUserToDomain(this RegisterUser userDto)
        {
            return new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
                Role = userDto.Role
            };
        }
    }
}
