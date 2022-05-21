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
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        [SecuredOperation("color.delete,admin")]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeletedSuccess);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorListSuccess);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.GetById(x => x.Id == id),Messages.ColorListByIdSuccess);
        }

        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        [SecuredOperation("color.insert,admin")]
        [PerformanceAspect(5)]
        public IResult Insert(Color color)
        {
            var result = BusinessRules.Run(CheckIfColorNameExists(color.Name));
            if (result != null)
            {
                return result;
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAddedSuccess);
        }

        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        [SecuredOperation("color.update,admin")]
        [PerformanceAspect(5)]
        public IResult Update(Color color)
        {
            var result = BusinessRules.Run(CheckIfColorNameExists(color.Name));
            if (result != null)
            {
                return result;
            }
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdatedSuccess);
        }

        private IResult CheckIfColorNameExists(string colorName)
        {
            var result = _colorDal.GetAll(x => x.Name == colorName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ColorNameExists);
            }
            return new SuccessResult();
        }
    }
}
