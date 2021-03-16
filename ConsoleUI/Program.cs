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
            //CarManagerTest();
            //AddRentalTest();
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

            userManager.Add(new User{Id =1,FirstName="İbrahim",LastName="Ensar", Email="ibrahim.ensar@hotmail.com",Password="123456a"});
            userManager.Add(new User { Id = 2, FirstName = "Fatma", LastName = "Kara", Email = "fatma.kara@hotmail.com", Password = "321654a" });
            userManager.Add(new User { Id = 3, FirstName = "Haydar", LastName = "Bahri", Email = "haydar.bahri@hotmail.com", Password = "987654a" });
            customerManager.Add(new Customer { CustomerId = 1, UserId = 1 , CompanyName="Saray A.Ş."});
            rentalManager.Add(new Rental { RentalId = 2, CarId = 1, CustomerId = 1, Rentdate=new DateTime(12,12,2012),ReturnDate=new DateTime(30,12,2012)});
        }
    }
}
