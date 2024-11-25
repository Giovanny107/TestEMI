using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestEMI.Application.DTO_s;
using TestEMI.Application.IServices;
using TestEMI.Core.Models;

namespace TestEMI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        /// <summary>
        /// This method return all employees.
        /// </summary>
        /// <returns> Employee list</returns>
        [HttpGet]
        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employeesList = await _employeeService.GetAllEmployees();
            return Ok(employeesList);
        }

        /// <summary>
        /// This method return a specific employee.
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns>Employee with all properties.</returns>
        [HttpGet("{id}")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            return Ok(employee);
        }

        /// <summary>
        /// This method return a list of employees who are part of a specific department.
        /// </summary>
        /// <param name="id">Department id</param>
        /// <returns>Employee with all properties.</returns>
        [HttpGet("{departmentId}")]
        [Route("ByDepartment")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> GetAllEmployeesByDepartment(int departmentId)
        {
            var employeeList = await _employeeService.GetAllEmployeesByDepartment(departmentId);
            return Ok(employeeList);
        }

        /// <summary>
        /// This method is use to create a new employee.
        /// </summary>
        /// <param name="employee">Employee has all properties needing to store. </param>
        /// <returns>New employee</returns>
        [HttpPost()]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> CreateEmployee(EmployeeDto employee)
        {
            var employeeAdd = await _employeeService.CreateEmployee(employee);
            return Ok(employeeAdd);
        }

        /// <summary>
        /// This method is use to update an employee.
        /// </summary>
        /// <param name="employee">Employee has all properties needing to update. </param>
        /// <returns>True if was updated or false otherwise.</returns>
        [HttpPut()]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto employee)
        {
            var result = await _employeeService.UpdateEmployee(employee);
            return Ok(result);
        }

        /// <summary>
        /// This method is use to delete an employee.
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns>True if was updated or false otherwise.</returns>
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminPolicy")]        
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployee(id);
            return Ok(result);
        }
    }
}
