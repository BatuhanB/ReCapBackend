using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, Context>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetils()
        {
            using Context context = new Context();
            var result = from c in context.Cars
                         join b in context.Brands
                         on c.BrandId equals b.Id
                         join co in context.Colors
                         on c.ColorId equals co.Id
                         select new CarDetailsDto
                         {
                             CarName = c.CarName,
                             BrandName = b.Name,
                             ColorName = co.Name,
                             DailyPrice = c.DailyPrice,
                             Description = c.Description,
                             ModelYear = c.ModelYear,
                             CarImages =(from i in context.CarImages where i.CarId == c.Id select i).ToList(),
                         };
            return result.ToList();
        }
    }
}
