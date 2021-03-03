using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManagerTest();
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + "/" + car.DailyPrice + "/" + car.BrandName + "/" + car.ColorName);
            }
        }
    }
}
