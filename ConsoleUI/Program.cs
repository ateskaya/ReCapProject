using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using Entities.Concrete;
using Core.Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + "/" + car.DailyPrice + "/" + car.BrandName + "/" + car.ColorName);
            }
        }
        private static void AddRentalTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            customerManager.Add(new Customer { CustomerId = 1, UserId = 1 , CompanyName="Saray A.Ş."});
            rentalManager.Add(new Rental { RentalId = 2, CarId = 1, CustomerId = 1, Rentdate=new DateTime(12,12,2012),ReturnDate=new DateTime(30,12,2012)});
        }
    }
}
