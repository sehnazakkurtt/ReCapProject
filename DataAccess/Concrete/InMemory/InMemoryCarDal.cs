using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal // sanal bellek sanki bir vt yapmış gibi
    {
        List<Car> _cars; // sanal vt
        public InMemoryCarDal()
        {
            _cars = new List<Car> { //nu bilgiler sanki bir vt geliyormuş gibi simüle ediyoruz
               new Car{CarId=1, BrandId= 1, ColorId=1 , ModelYear="1994", DailyPrice=2, Description="klasik araba"},
                new Car{CarId=2, BrandId= 2, ColorId=2, ModelYear="1998", DailyPrice=5, Description="spor araba" },
                new Car{CarId=3, BrandId= 3, ColorId=3 , ModelYear="2000", DailyPrice=3, Description="jip "
               },
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate= _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }


    
        
    }
}
