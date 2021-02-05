using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;
		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}
		public void Add(Car car)
		{
			if (car.DailyPrice > 0)
			{
				_carDal.Add(car);
				Console.WriteLine("{0} nolu, modeli -{1}-, rengi -{2}-, çıkış yılı -{3}- günlük fiyatı -{4}-, açıklaması -{5}- olan araba sisteme eklenmiştir.", car.CarID, car.BrandID, car.ColorID, car.ModelYear, car.DailyPrice, car.Description);
			}
			else
			{
				Console.WriteLine("Girilen günlük fiyat 0 TL 'den fazla olmalıdır. Tekrar deneyin.");
				car.DailyPrice = Convert.ToInt32(Console.ReadLine());
			}
		}

		public void Delete(Car car)
		{
			_carDal.Delete(car);
			Console.WriteLine("Araba silindi.");
		}

		public List<Car> GetAllByBrandID(int brandID)
		{
			return _carDal.GetAll(c => c.BrandID == brandID);
		}

		public List<Car> GetAllByColorID(int colorID)
		{
			return _carDal.GetAll(c => c.ColorID == colorID);
		}

		public List<Car> GetByDailyPrice(decimal min, decimal max)
		{
			return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
		}

		public Car GetByID(int id)
		{
			return _carDal.Get(c => c.CarID == id);
		}

		public List<Car> GetByModelYear(int year)
		{
			return _carDal.GetAll(c => c.ModelYear == year);
		}

		public List<Car> GetCar()
		{
			return _carDal.GetAll();
		}

		public void Update(Car car)
		{
			if (car.DailyPrice > 0)
			{
				_carDal.Add(car);
				Console.WriteLine("{0} nolu, modeli -{1}-, rengi -{2}-, çıkış yılı -{3}- günlük fiyatı -{4}-, açıklaması -{5}- olan araba güncellenmiştir.", car.CarID, car.BrandID, car.ColorID, car.ModelYear, car.DailyPrice, car.Description);
			}
			else
			{
				Console.WriteLine("Girilen günlük fiyat 0 TL 'den fazla olmalıdır. Tekrar deneyin.");
				car.DailyPrice = Convert.ToInt32(Console.ReadLine());
			}
		}
	}
}
