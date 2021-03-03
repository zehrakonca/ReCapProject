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
		IResult Add(Car car);
		IResult Update(Car car);
		IResult Delete(Car car);
		IDataResult<List<Car>> GetCar();
		IDataResult<Car> GetByID(int id);
		IDataResult<List<CarDetailDto>> GetCarDetails();
		IDataResult<List<Car>> GetAllByColorID(int colorID);
		IDataResult<List<Car>> GetAllByBrandID(int brandID);
		IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
		IDataResult<List<Car>> GetByModelYear(int year);
	}
}
