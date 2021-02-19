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
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		[ValidationAspect(typeof(BrandValidator))]
		public IResult Add(Brand brand)
		{
			_brandDal.Add(brand);
			return new SuccessResult(Messages.BrandAdded);
		}

		public IResult Delete(Brand brand)
		{
			_brandDal.Delete(brand);
			return new SuccessResult(Messages.BrandDelete);
		}

		public IDataResult<List<Brand>> GetAll()
		{
			return new DataResult<List<Brand>>(_brandDal.GetAll(), true);
		}

		public IDataResult<Brand> GetById(int brandID)
		{
			return new DataResult<Brand>(_brandDal.Get(b => b.BrandID == brandID), true);
		}

		[ValidationAspect(typeof(BrandValidator))]
		public IResult Update(Brand brand)
		{
			_brandDal.Update(brand);
			return new SuccessResult();
		}
	}
}
