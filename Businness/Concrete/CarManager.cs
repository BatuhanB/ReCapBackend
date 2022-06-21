using Businness.Abstract;
using Businness.BusinessAspects.Autofac;
using Businness.Constants;
using Businness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Performance;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [PerformanceAspect(5)]
        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Insert(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAddedSuccess);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListSuccess);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.BrandId == id), Messages.CarListByBrandSuccess);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.ColorId == id), Messages.CarListByColorSuccess);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.GetById(x => x.Id == id), Messages.CarListByIdSuccess);
        }

        [SecuredOperation("car.update,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdatedSuccess);
        }

        [PerformanceAspect(5)]
        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("car.delete,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeletedSuccess);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarDetails(int id)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(x=>x.CarId == id), Messages.CarListSuccess);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetail(),Messages.CarListSuccess);
        }
    }
}
