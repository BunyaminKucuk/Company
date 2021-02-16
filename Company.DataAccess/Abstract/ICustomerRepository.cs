using System;
using System.Collections.Generic;
using System.Text;
using Company.Entities;

namespace Company.DataAccess.Abstract
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers(); 
        Customer GetCustomerById(int id);
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}
