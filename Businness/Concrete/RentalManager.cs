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
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        [PerformanceAspect(5)]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeletedSuccess);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListSuccess);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetById(x => x.Id == id), Messages.RentalListByIdSuccess);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalDetailsListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        [PerformanceAspect(5)]
        public IResult Insert(Rental rental)
        {
            var rentDate = BusinessRules.Run(CheckRentDate(rental));
            if (rentDate != null)
            {
                return rentDate;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAddedSuccess);
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalUpdatedSuccess);
        }
        private IResult CheckRentDate(Rental rental)
        {
            var result = _rentalDal.GetAll(x => x.CarId == rental.CarId 
                                        && x.ReturnDate >= rental.ReturnDate 
                                        && x.RentDate <= rental.RentDate).Any();
            if (result)
            {
                return new ErrorResult("This car is rented between these dates");
            }
            else
            {
                return new SuccessResult();
            }
        }
    }
}
