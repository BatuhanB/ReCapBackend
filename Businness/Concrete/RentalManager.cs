using Businness.Abstract;
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
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetById(x=>x.Id == id));
        }

        public IResult Insert(Rental rental)
        {
            if(rental.ReturnDate != null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult("Araba kiralama başarılı!");
            }
            return new ErrorResult("Araba henüz teslim edilmemiştir.");
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }
    }
}
