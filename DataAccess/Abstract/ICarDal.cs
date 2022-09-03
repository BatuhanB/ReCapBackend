﻿using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null);
        List<CarDetailsDto> GetCarDetail(Expression<Func<CarDetailsDto, bool>> filter = null);
    }
}
