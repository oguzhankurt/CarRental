using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (CarContext context = new CarContext())
            {
                var result = from p in context.Cars
                             join c in context.Colors
                             on p.ColorId equals c.Id
                             join d in context.Brands
                             on p.BrandId equals d.Id
                             select new CarDetailDto { Id = p.Id, Brand = d.Name, Color = c.Name, DailyPrice = p.DailyPrice, ModelYear = p.ModelYear, Description = p.Description };
                return result.ToList();
            }
        }
    }
}
