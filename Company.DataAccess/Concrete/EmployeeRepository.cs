using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.DataAccess.Abstract;
using Company.Entities;

namespace Company.DataAccess.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Employee CreateEmployee(Employee employee)
        {
            using var employeeDbContext = new CompanyDbContext();
            employeeDbContext.Employees.Add(employee);
            employeeDbContext.SaveChanges(); 
            return employee;
        }

        public void DeleteEmployee(int id)
        {
            using var employeeDbContext = new CompanyDbContext();
            var deletedEmployee = GetEmployeeById(id);
            employeeDbContext.Employees.Remove(deletedEmployee);
            employeeDbContext.SaveChanges();
        }

        public List<Employee> GetAllEmployees()
        {
            using var employeeDbContext = new CompanyDbContext();
            return employeeDbContext.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            using var employeeDbContext = new CompanyDbContext();
            return employeeDbContext.Employees.Find(id);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            using var employeeDbContext = new CompanyDbContext();
            employeeDbContext.Employees.Update(employee);
            employeeDbContext.SaveChanges();
            return employee;
        }
    }
}
