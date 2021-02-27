using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete
{

    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{Id=1,BrandId=1,ColorId=3,ModelYear="2016",DailyPrice=150,Description="4.5 lt/100km yakan i7"},
                new Car{Id=2,BrandId=1,ColorId=2,ModelYear="2005",DailyPrice=100,Description="3.5 lt/100km yakan i3"},
                new Car{Id=3,BrandId=2,ColorId=1,ModelYear="2019",DailyPrice=200,Description="6.5 lt/100km yakan Golf"},
                new Car{Id=4,BrandId=2,ColorId=3,ModelYear="2017",DailyPrice=175,Description="5.5 lt/100km yakan Passat"},
            };
        }

        public void Add(Car product)
        {
            _cars.Add(product);
        }

        public void Delete(Car product)
        {
            Car productToDelete = _cars.SingleOrDefault(p => p.Id == product.Id);
            _cars.Remove(productToDelete);
        }


        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public void Update(Car product)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == product.Id);
            carToUpdate.BrandId = product.BrandId;
            carToUpdate.ColorId = product.ColorId;
            carToUpdate.DailyPrice = product.DailyPrice;
            carToUpdate.Description = product.Description;
            carToUpdate.ModelYear = product.ModelYear;
        }
    }
}
