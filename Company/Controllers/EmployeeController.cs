using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Business.Abstract;
using Company.Business.Concrete;
using Company.Entities;

namespace Company.API.Controllers
{
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController()
        {
            _employeeService=new EmployeeManager();
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetEmployee()
        {
            var employee = _employeeService.GetAllEmployees();
            return Ok(employee);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee!=null)
            {
                return Ok(employee);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            var createdEmployee = _employeeService.CreateEmployee(employee);
            return CreatedAtAction("Get", new {id = createdEmployee.EmployeeId}, createdEmployee);
        }

        [HttpPut]
        [Route("update")]

        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            if (_employeeService.GetEmployeeById(employee.EmployeeId) != null)
            {
                return Ok(_employeeService.UpdateEmployee(employee));//201+data
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteEmployee(int id)
        {
            _employeeService.DeleteEmployee(id);
        }

    }
}
