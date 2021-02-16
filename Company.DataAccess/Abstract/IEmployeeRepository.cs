using System;
using System.Collections.Generic;
using System.Text;
using Company.Entities;

namespace Company.DataAccess.Abstract
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        Employee CreateEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
