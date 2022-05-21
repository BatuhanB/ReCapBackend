using Businness.Abstract;
using Businness.BusinessAspects.Autofac;
using Businness.Constants;
using Businness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Performance;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [SecuredOperation("brand.delete,admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        [ValidationAspect(typeof(BrandValidator))]
        [PerformanceAspect(5)]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeletedSuccess);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListSuccess);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.GetById(x => x.Id == id),Messages.BrandListByIdSuccess);
        }

        [PerformanceAspect(5)]
        [SecuredOperation("brand.insert,admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Insert(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckIfBrandNameExists(brand.Name));
            if (result != null)
            {
                return result;
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAddedSuccess);
        }

        [SecuredOperation("brand.update,admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckIfBrandNameExists(brand.Name));
            if (result != null)
            {
                return result;
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdatedSuccess);
        }
        private IResult CheckIfBrandNameExists(string brandName)
        {
            var result = _brandDal.GetAll(x=>x.Name == brandName).Any();
            if (result)
            {
                return new ErrorResult(Messages.BrandNameExists);
            }
            return new SuccessResult();
        }
    }
}
