using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstact;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
		public IResult Add(Car car)
		{
			if (car.DailyPrice > 0)
			{
				_carDal.Add(car);
				return new SuccessResult(Messages.CarAdded);
			}
			else
			{
				return new ErrorResult(Messages.cantDailyPrice);
			}
		}

		public IResult Delete(Car car)
		{
			_carDal.Delete(car);
			return new Result(true, "araba silindi.");
		}

		public IDataResult<List<Car>> GetAllByBrandID(int brandID)
		{
			return new DataResult<List<Car>>(_carDal.GetAll(c => c.BrandID == brandID),true);
		}

		public IDataResult<List<Car>> GetAllByColorID(int colorID)
		{
			return new DataResult<List<Car>>(_carDal.GetAll(c => c.ColorID == colorID), true);
		}

		public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
		{
			return new DataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), true);
		}

		public IDataResult<Car> GetByID(int id)
		{
			return new DataResult<Car>(_carDal.Get(c => c.CarID == id), true);
		}

		public IDataResult<List<Car>> GetByModelYear(int year)
		{
			return new DataResult<List<Car>>(_carDal.GetAll(c => c.ModelYear == year), true);
		}

		public IDataResult<List<Car>> GetCar()
		{
			return new DataResult<List<Car>>(_carDal.GetAll(), true);
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new DataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), true);
		}

		public IResult Update(Car car)
		{
			if (car.DailyPrice > 0)
			{
				_carDal.Update(car);
				return new SuccessResult(Messages.CarUpdated);
			}
			else
			{
				return new ErrorResult(Messages.cantDailyPrice);
			}
		}
	}
}
