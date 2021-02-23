﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        Car GetById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetCarColor(int id);
        void Delete(Car car);
        IResult Update(Car car);
        IResult Add(Car car);
    }
}
