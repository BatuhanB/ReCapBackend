﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>>  GetAll();
        IDataResult<Brand> GetById(int id);
        IResult Insert(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
    }
}
