using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //var result = carManager.Add(new Car { BrandId = 2, ColorId = 1, DailyPrice = 250, ModelYear = 2018, Description = "Uzun yol aracı" });
            //Console.WriteLine(carManager.GetById(2).Description);
            //var result = carManager.Update(new Car { Id = 1003, BrandId = 3, ColorId = 2, ModelYear = 2010, DailyPrice = 500, Description = "Arazi aracı" });
            
            //carManager.Delete(new Car { Id = 1002 });

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand { Name = "Mercedes" });

            ColorManager colorManager = new ColorManager(new EfColorDal());
            //var result = colorManager.Add(new Color { Name = "Gri" });
            //Console.WriteLine(result.Message);

            var result = carManager.GetCarDetails();
            foreach (var item in result.Data)
            {
                Console.WriteLine("Adı " + item.Brand + ", Renk: " + item.Color + ", Açıklama: " + item.Description + ", Fiyat: " + item.DailyPrice);
            }
        }
    }
}
