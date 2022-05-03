using Businness.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarListTest();       //---> Çalışıyor.
            //CarAddTest();       //---> Çalışıyor.
            //BrandListTest();   //---> Çalışıyor.
            //BrandAddTest();   //---> Çalışıyor.
            //ColorListTest(); //---> Çalışıyor.
            //ColorAddTest(); //---> Çalışıyor.

        }

        private static void ColorAddTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color1 = new Color()
            {
                Name = "Beyaz"
            };
            colorManager.Insert(color1);
        }

        private static void ColorListTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var item in colorManager.GetAll())
            {
                Console.WriteLine(item.Id + "\n" + item.Name);
            }
        }

        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand1 = new Brand()
            {
                Name = "320i"
            };
            brandManager.Insert(brand1);
        }

        private static void BrandListTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var item in brandManager.GetAll())
            {
                Console.WriteLine(item.Id + "\n" + item.Name);
            }
        }

        private static void CarListTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.CarName + " " + item.BrandName + " " + item.ColorName + " " + item.DailyPrice);
            }
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car();

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
