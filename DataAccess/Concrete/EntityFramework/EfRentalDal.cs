using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, Context>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
             using var context = new Context();
            var result = from ren in context.Rentals
                         join us in context.Users
                         on ren.CustomerId equals us.Id
                         join bra in context.Brands
                         on ren.CarId equals bra.Id
                         select new RentalDetailDto
                         {
                             BrandName = bra.Name,
                             CustomerName = us.FirstName + " " + us.LastName,
                             RentDate = ren.RentDate,
                             ReturnDate = ren.ReturnDate,
                         };
            return result.ToList();
                         
        }
    }
}
