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
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<Car> Get(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<CarDetailDto> GetCarDetail(int id);
        IDataResult<List<Car>> GetCarColor(int id);
        IResult Delete(Car car);
        IResult Update(Car car);
        IResult Add(Car car);
    }
}
