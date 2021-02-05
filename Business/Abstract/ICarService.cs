using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface ICarService
	{
		void Add(Car car);
		void Update(Car car);
		void Delete(Car car);
		List<Car> GetCar();
		Car GetByID(int id);
		List<Car> GetAllByColorID(int colorID);
		List<Car> GetAllByBrandID(int brandID);
		List<Car> GetByDailyPrice(decimal min, decimal max);
		List<Car> GetByModelYear(int year);
	}
}
