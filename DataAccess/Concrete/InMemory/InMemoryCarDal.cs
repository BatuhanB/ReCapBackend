using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> { new Car { Id = 1,BrandId = 1,ColorId= 1,DailyPrice=120,ModelYear="2015",Description= "2015 Model BMW 320d günlük ki" +
                "ralama" } };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carDelete = _cars.FirstOrDefault(x=>x.Id == car.Id);
            _cars.Remove(carDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarById(int id)
        {
             return _cars.Where(x => x.Id == id).ToList();
        }

        public List<CarDetailsDto> GetCarDetail(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var carUpdate = _cars.FirstOrDefault(x => x.Id == car.Id);
            carUpdate.BrandId = car.BrandId;
            carUpdate.ModelYear = car.ModelYear;
            carUpdate.Description = car.Description;
            carUpdate.ColorId = car.ColorId;
        }
    }
}
