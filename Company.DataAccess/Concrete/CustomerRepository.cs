using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.DataAccess.Abstract;
using Company.Entities;

namespace Company.DataAccess.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer CreateCustomer(Customer customer)
        {
            using var customerDbContext=new CompanyDbContext();
            customerDbContext.Customers.Add(customer);
            customerDbContext.SaveChanges();
            return customer;
        }

        public void DeleteCustomer(int id)
        {
            using var customerDbContext=new CompanyDbContext();
            var deletedCustomer = GetCustomerById(id);
            customerDbContext.Customers.Remove(deletedCustomer);
            customerDbContext.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            using var customerDbContext = new CompanyDbContext();
            return customerDbContext.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            using var customerDbContext = new CompanyDbContext();
            return customerDbContext.Customers.Find(id);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            using var customerDbContext = new CompanyDbContext();
            customerDbContext.Customers.Update(customer);
            customerDbContext.SaveChanges();
            return customer;
        }
    }
}
