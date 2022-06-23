using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailsDto>> GetCarsByBrandId(int id);
        IDataResult<List<CarDetailsDto>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailsDto>> GetCarDetails(int id);
        IDataResult<List<CarDetailsDto>> GetCarDetail();
        IDataResult<Car> GetById(int id);
        IResult Insert(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
