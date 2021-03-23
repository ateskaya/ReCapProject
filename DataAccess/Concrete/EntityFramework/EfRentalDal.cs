using Core.DataAccess.EntityFramework;
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
    public class EfRentalDal:EfEntityRepositoryBase<Rental,ReCapProjectContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from rnt in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join ca in context.Cars2
                             on rnt.CarId equals ca.Id
                             join cst in context.Customers
                             on rnt.CustomerId equals cst.CustomerId
                             join usr in context.Users
                             on cst.UserId equals usr.Id
                             select new RentalDetailDto
                             {
                                 Id = rnt.RentalId,
                                 CarName = ca.CarName,
                                 RentDate = (DateTime)rnt.Rentdate,
                                 ReturnDate =(DateTime) rnt.ReturnDate,
                                 CompanyName = cst.CompanyName,
                                 FirstName = usr.FirstName,
                                 LastName = usr.LastName,
                                 Email = usr.Email,
                                 


                             };
                return result.ToList();
            }
        }

    }
}
