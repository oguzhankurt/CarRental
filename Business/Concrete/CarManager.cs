using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.BusinessAspect.Autofac;
using Core.Aspect.Autofac.Caching;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.AddCar);
        }

        [SecuredOperation("admin")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDelete);
        }

        public IDataResult<Car> Get(Car car)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == car.Id));
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == carId));
        }

        public IDataResult<List<Car>> GetCarColor(int id)
        {
            Console.WriteLine(id);
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<CarDetailDto> GetCarDetail(int id)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetail(p => p.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdate);
        }
    }
}
