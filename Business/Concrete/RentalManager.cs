using Business.Abstract;
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
	public class RentalManager : IRentService
	{
		IRentDal _rentDal;
		public RentalManager(IRentDal rentDal)
		{
			_rentDal = rentDal;
		}

		[ValidationAspect(typeof(RentalValidator))]
		public IResult Add(Rental rent)
		{
			_rentDal.Add(rent);
			return new SuccessResult();
		}

		public IResult Delete(Rental rent)
		{
			_rentDal.Delete(rent);
			return new SuccessResult();
		}

		public IDataResult<Rental> GetByID(int id)
		{
			return new SuccessDataResult<Rental>(_rentDal.Get(r => r.RentalID == id));
		}

		public IDataResult <List<CarRentDetailDto>> GetRentCarDetails()
		{
			return new SuccessDataResult<List<CarRentDetailDto>>(_rentDal.GetRentCarDetails());
		}

		public IDataResult<List<Rental>> GetRentCar()
		{
			return new SuccessDataResult<List<Rental>>(_rentDal.GetAll());
		}

		[ValidationAspect(typeof(RentalValidator))]
		public IResult Update(Rental rent)
		{
			_rentDal.Update(rent);
			return new SuccessResult();
		}
	}
}
