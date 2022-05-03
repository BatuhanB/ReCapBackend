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
            CarManager carManager = new CarManager(new EfCarDal());
            //foreach(var item in carManager.GetAll())
            //{
            //    Console.WriteLine("id: " + item.Id + "\nMarka id: " + item.BrandId +
            //        "\nRenk id: " + item.ColorId + "\nModel Yılı: " + item.ModelYear +
            //        "\nGünlük Fiyat: " + item.DailyPrice + "TL\nAçıklama: " + item.Description);
            //}
            Car car1 = new Car();
            car1.BrandId = 1;
            car1.ModelYear = "2012";
            car1.DailyPrice = 120;
            car1.Description = "abaa";
            car1.Id = 2;
            car1.ColorId = 3;

            carManager.Add(car1);
        }
    }
}
