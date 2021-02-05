using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			CarManager carManager = new CarManager(new EfCarDal());
			BrandManager brandManager = new BrandManager(new EfBrandDal());
			ColorManager colorManager = new ColorManager(new EfColorDal());
			Console.WriteLine("Sistemdeki bütün arabalar: \nId\tAraç Rengi\tModel\tÇıkış Yılı\tGünlük Fiyat\tAçıklama");
			foreach (var car in carManager.GetCar())
			{
				Console.WriteLine($"{car.CarID}\t{colorManager.GetById(car.ColorID).ColorName}\t{brandManager.GetById(car.BrandID).BrandName}\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
			}
			Console.WriteLine("__________________________________________________________________________");

			Console.WriteLine("Sistemdeki kırmızı arabalar: \nId\tAraç Rengi\tModel\tÇıkış Yılı\tGünlük Fiyat\tAçıklama");
			foreach (var car in carManager.GetAllByColorID(3))
			{
				Console.WriteLine($"{car.CarID}\t{colorManager.GetById(car.ColorID).ColorName}\t{brandManager.GetById(car.BrandID).BrandName}\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
			}
			Console.WriteLine("__________________________________________________________________________");
			Console.WriteLine("Sistemdeki SUV tip arabalar:\nId\tAraç Rengi\tModel\tÇıkış Yılı\tGünlük Fiyat\tAçıklama");
			foreach (var car in carManager.GetAllByBrandID(1))
			{
				Console.WriteLine($"{car.CarID}\t{colorManager.GetById(car.ColorID).ColorName}\t{brandManager.GetById(car.BrandID).BrandName}\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
			}
			Console.WriteLine("__________________________________________________________________________");
			Console.WriteLine("Sistemdeki 100 TL ile 400 TL arasındaki arabalar: \nId\tAraç Rengi\tModel\tÇıkış Yılı\tGünlük Fiyat\tAçıklama");
			foreach (var car in carManager.GetByDailyPrice(100, 400))
			{
				Console.WriteLine($"{car.CarID}\t{colorManager.GetById(car.ColorID).ColorName}\t{brandManager.GetById(car.BrandID).BrandName}\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
			}
			carManager.Add(new Car { BrandID = 4, ColorID = 5, DailyPrice = 700, ModelYear = 2021, Description = "Manuel Gazlı" });
			brandManager.Add(new Brand { BrandName = "Traktör" });

			Console.ReadLine();
		}
	}
}
