using Businness.Abstract;
using Businness.BusinessAspects.Autofac;
using Businness.Constants;
using Businness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Performance;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        //[SecuredOperation("carImage.add,admin")]
        [PerformanceAspect(5)]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageCount(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            var imageResult = FileHelper.Upload(file);
            if (!imageResult.IsSuccess)
            {
                return new ErrorResult("");
            }
            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        [SecuredOperation("carImage.delete,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [PerformanceAspect(5)]
        public IResult Delete(CarImage carImage)
        {
            var result = _carImageDal.GetById(x => x.Id == carImage.Id);
            if (result == null)
            {
                return new ErrorResult("Image not found");
            }
            FileHelper.Delete(result.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult("Image was deleted succesfully");
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        [SecuredOperation("carImage.update,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var updatedFile = FileHelper.Update(file, carImage.ImagePath);
            if (!updatedFile.IsSuccess)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult("Car image has been updated");
        }

        private IResult CheckImageCount(int id)
        {
            var result = _carImageDal.GetAll(x => x.CarId == id).Count();
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageLimit);
            }
            return new SuccessResult();
        }
    }
}