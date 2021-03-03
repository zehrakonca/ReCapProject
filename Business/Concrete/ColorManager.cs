using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class ColorManager : IColorService
	{
		IColorDal _colorDal;
		public ColorManager(IColorDal colorDal)
		{
			_colorDal = colorDal;
		}
		[SecuredOperation("Admin")]
		[ValidationAspect(typeof(ColorValidator))]
		public IResult Add(Color color)
		{
			_colorDal.Add(color);
			return new SuccessResult(Messages.ColorAdded);
		}

		[SecuredOperation("Admin")]
		public IResult Delete(Color color)
		{
			_colorDal.Delete(color);
			return new SuccessResult(Messages.ColorDeleted);
		}

		public IDataResult<List<Color>> GetAll()
		{
			return new DataResult<List<Color>>(_colorDal.GetAll(), true);
		}

		public IDataResult<Color> GetById(int colorID)
		{
			return new DataResult<Color>(_colorDal.Get(c => c.ColorID == colorID), true);
		}
		[SecuredOperation("Admin")]
		[ValidationAspect(typeof(ColorValidator))]
		public IResult Update(Color color)
		{
			_colorDal.Update(color);
			return new SuccessResult();
		}
	}
}
