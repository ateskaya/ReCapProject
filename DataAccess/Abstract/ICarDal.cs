using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetAll();
        List<Car> GetById(int getById);
        void Add(Car product);
        void Update(Car product);
        void Delete(Car product);
    }
}
