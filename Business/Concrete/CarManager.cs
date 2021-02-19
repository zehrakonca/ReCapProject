using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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

		[ValidationAspect(typeof(CarValidator))]
		public IResult Add(Car car)
		{
			_carDal.Add(car);
			return new SuccessResult(Messages.CarAdded);
		}

		public IResult Delete(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult(Messages.UserDeleted);
		}

		public IDataResult<List<Car>> GetAllByBrandID(int brandID)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandID == brandID), Messages.HasBeenListed);
		}

		public IDataResult<List<Car>> GetAllByColorID(int colorID)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorID == colorID), Messages.HasBeenListed);
		}

		public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), Messages.HasBeenListed);
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
			return new SuccessDataResult<List<Car>>(_carDal.GetAll());
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
		}


		[ValidationAspect(typeof(CarValidator))]
		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult(Messages.CarUpdated);
		}
	}
}
