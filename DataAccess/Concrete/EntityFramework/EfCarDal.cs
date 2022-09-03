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
        public List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            using var context = new Context();
            var result = from c in context.Cars
                         join b in context.Brands on c.BrandId equals b.Id
                         join co in context.Colors on c.ColorId equals co.Id
                         select new CarDetailsDto()
                         {
                             CarId = c.Id,
                             BrandId = b.Id,
                             ColorId = co.Id,
                             CarName = c.CarName,
                             BrandName = b.Name,
                             ColorName = co.Name,
                             DailyPrice = c.DailyPrice,
                             Description = c.Description,
                             ModelYear = c.ModelYear,
                             CarImages = (from i in context.CarImages where i.CarId == c.Id select i).ToList(),
                         };
            return filter == null ? result.ToList() : result.Where(filter).ToList();
        }
        public List<CarDetailsDto> GetCarDetail(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            using var context = new Context();
            var result = from c in context.Cars
                         join b in context.Brands on c.BrandId equals b.Id
                         join co in context.Colors on c.ColorId equals co.Id
                         select new CarDetailsDto()
                         {
                             CarId = c.Id,
                             BrandId = b.Id,
                             ColorId = co.Id,
                             BrandName = b.Name,
                             CarName = c.CarName,
                             ColorName = co.Name,
                             DailyPrice = c.DailyPrice,
                             ModelYear = c.ModelYear,
                             Description = c.Description,
                             CarImages = (from i in context.CarImages where i.CarId == c.Id select i).ToList(),
                         };
            return result.ToList();
        }

    }
}
