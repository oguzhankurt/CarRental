using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        void Delete(Car car);
        IResult Update(Car car);
        IResult Add(Car car);
    }
}
