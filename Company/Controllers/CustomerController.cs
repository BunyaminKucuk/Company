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
    [Route("api/customer")]

    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController()
        {
            _customerService = new CustomerManager();
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetCustomer()
        {
            var customer = _customerService.GetAllCustomers();
            return Ok(customer);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public IActionResult GetCorporationById(int id)
        {
            var customers = _customerService.GetCustomerById(id);
            if (customers != null)
            {
                return Ok(customers);
            }
            return NotFound();//404
        }

        [HttpPost]
        [Route("add")]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            var createdCustomer = _customerService.CreateCustomer(customer);
            return CreatedAtAction("Get", new { id = createdCustomer.CustomerId }, createdCustomer);//201+data
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateCustomer([FromBody] Customer customer)
        {
            if (_customerService.GetCustomerById(customer.CustomerId) != null)
            {
                return Ok(_customerService.UpdateCustomer(customer));//201+data
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteCustomer(int id)
        {
            _customerService.DeleteCustomer(id);
        }
    }
}
