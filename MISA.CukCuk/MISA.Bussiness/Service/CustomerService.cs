using MISA.Bussiness.Interfaces;
using MISA.Common.Models;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class CustomerService : ICustomerBussiness
    {
        ICustomerRepository _customerRepository
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomer()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Customer employee)
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid id, Customer employee)
        {
            throw new NotImplementedException();
        }
    }
}
