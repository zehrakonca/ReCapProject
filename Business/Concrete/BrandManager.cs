﻿using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
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
		[SecuredOperation("Admin")]
		[ValidationAspect(typeof(BrandValidator))]
		public IResult Add(Brand brand)
		{
			_brandDal.Add(brand);
			return new SuccessResult(Messages.BrandAdded);
		}
		[SecuredOperation("Admin")]
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
		[SecuredOperation("Admin")]
		[ValidationAspect(typeof(BrandValidator))]
		public IResult Update(Brand brand)
		{
			_brandDal.Update(brand);
			return new SuccessResult();
		}
	}
}
