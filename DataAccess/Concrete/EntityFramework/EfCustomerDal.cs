using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarDBContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentACarDBContext context = new RentACarDBContext())
            {
                var result = from u in context.Users
                             join cu in context.Customers
                             on u.Id equals cu.UserId
                             join c in context.Cars
                             on cu.CarId equals c.CarId
                             select new CustomerDetailDto
                             {
                                 CustomerId = cu.CustomerId,
                                 UserId = u.Id,
                                 CarId = c.CarId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 CompanyName = cu.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
