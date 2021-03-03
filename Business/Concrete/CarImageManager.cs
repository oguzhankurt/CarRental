using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage entity)
        {
            
            var result = BusinessRules.Run(CheckIfCarImageLimitExceded(entity.CarId));
            if(result != null)
            {
                return result;
            }
            entity.ImagePath = FileHelper.AddAsync(file);
            entity.Date = DateTime.Now;
            _carImageDal.Add(entity);
            return new SuccessResult("Görsel Eklendi");
        }

        public IResult Delete(CarImage entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImage> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile file, CarImage entity)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfCarImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if(result > 6)
            {
                return new ErrorResult("5 ten fazla araba eklenemez");
            }
            return new SuccessResult();
        }
    }
}
