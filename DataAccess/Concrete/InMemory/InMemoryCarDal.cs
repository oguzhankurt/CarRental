using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{ Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 500, ModelYear = 2020, Description = "Konforlu ve rahat"},
                new Car{ Id = 2, BrandId = 2, ColorId = 1, DailyPrice = 400, ModelYear = 2018, Description = "Konforlu ve rahat 2"}
            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car result = null;
            foreach (var item in _car)
            {
                if (item.Id == car.Id)
                {
                    result = item;
                };
            }
            _car.Remove(result);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int carId)
        {
            Car result = null; //newleme yapma referans kaybolur.
            foreach (var item in _car)
            {
                if (item.Id == carId)
                {
                    result = item;
                }
            }
            return result;

        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetail(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car result = null;
            foreach (var item in _car)
            {
                if (item.Id == car.Id)
                {
                    result = item;
                    result.DailyPrice = car.DailyPrice;
                }
            }
            _car.Contains(result);
        }

        CarDetailDto ICarDal.GetCarDetail(Expression<Func<CarDetailDto, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
