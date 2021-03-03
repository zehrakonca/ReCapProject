using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
		[SecuredOperation("Admin Customer")]
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

		public IDataResult <List<CarRentDetailDto>> GetRentCarDetails(Expression<Func<Rental, bool>> filter = null)
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
