using Businness.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarListTest();               //---> Çalışıyor.
            //CarAddTest();               //---> Çalışıyor.
            //BrandListTest();           //---> Çalışıyor.
            //BrandAddTest();           //---> Çalışıyor.
            //ColorListTest();         //---> Çalışıyor.
            //ColorAddTest();         //---> Çalışıyor.
            //UserAddTest();         //---> Çalışıyor.
            //UserListTest();       //---> Çalışıyor.
            //CustomerAddTest();   //---> Çalışıyor.
            //CustomerListTest(); //---> Çalışıyor.
            //RentalAddTest();   //---> Çalışıyor.
            //RentalListTest(); //---> Çalışıyor.
        }

        private static void RentalListTest()
        {
            var rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.CarId
                    + "\n" + item.CustomerId
                    + "\n" + item.RentDate
                    + "\n" + item.ReturnDate);
                Console.WriteLine("------------");
            }
        }

        private static void RentalAddTest()
        {
            var rentalManager = new RentalManager(new EfRentalDal());
            var rental = new Rental()
            {
                CarId = 1,
                CustomerId = 2,
                RentDate = DateTime.Now,
                //ReturnDate = DateTime.Parse("2022-06-05"),
               //ReturnDate = null,//return date'i null geçersek db'ye ekleme yapmıyor
            };
            rentalManager.Insert(rental);
        }

        private static void CustomerListTest()
        {
            var customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.UserId + "\n" + item.CompanyName);
            }
        }

        private static void CustomerAddTest()
        {
            var customerManager = new CustomerManager(new EfCustomerDal());
            var customer = new Customer()
            {
                CompanyName = "BBCorp"
            };
            customerManager.Insert(customer);
        }

        private static void UserListTest()
        {
            var userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.Id
                    + "\n" + item.FirstName
                    + "\n" + item.LastName
                    + "\n" + item.Email
                    + "\n" + item.Password);
                Console.WriteLine(result.Message);
            }
        }

        private static void UserAddTest()
        {
            var userManager = new UserManager(new EfUserDal());
            var user1 = new User()
            {
                FirstName = "Batuhan",
                LastName = "Balı",
                Email = "bb19@gmail.com",
                Password = "123456"
            };
            userManager.Insert(user1);
        }

        private static void ColorAddTest()
        {
            var colorManager = new ColorManager(new EfColorDal());
            var color1 = new Color()
            {
                Name = "Beyaz"
            };
            colorManager.Insert(color1);
        }

        private static void ColorListTest()
        {
            var colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if (result.IsSuccess == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Id + "\n" + item.Name);
                }
            }
        }

        private static void BrandAddTest()
        {
            var brandManager = new BrandManager(new EfBrandDal());
            var brand1 = new Brand()
            {
                Name = "320i"
            };
            brandManager.Insert(brand1);
        }

        private static void BrandListTest()
        {
            var brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.IsSuccess == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Id + "\n" + item.Name);
                }
            }
        }

        private static void CarListTest()
        {
            var carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetail();
            if (result.IsSuccess == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.CarName + " " + item.BrandName + " " + item.ColorName + " " + item.DailyPrice);
                }
            }
        }

        private static void CarAddTest()
        {
            var carManager = new CarManager(new EfCarDal());
            var car1 = new Car();

            car1.CarName = "BMW";
            car1.BrandId = 2;
            car1.ColorId = 2;
            car1.ModelYear = "2012";
            car1.DailyPrice = 340;
            car1.Description = "Bu araç günlük kiralama için oldukça uygundur.";

            carManager.Insert(car1);
        }
    }
}
