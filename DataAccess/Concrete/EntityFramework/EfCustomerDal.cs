using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (var context = new CarContext())
            {
                var result = from u in context.Users
                             join customer in context.Customers
                                 on u.UserId equals customer.UserId
                             select new CustomerDetailDto
                             { Id = u.UserId, Company = customer.CompanyName, Name = u.FirstName + " " + u.LastName };
                return result.ToList();
            }
        }

    }
}
