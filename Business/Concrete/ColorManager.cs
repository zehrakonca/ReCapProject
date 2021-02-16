﻿using Business.Abstract;
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
	public class ColorManager : IColorService
	{
		IColorDal _colorDal;
		public ColorManager(IColorDal colorDal)
		{
			_colorDal = colorDal;
		}

		public IResult Add(Color color)
		{
			if (color.ColorName.Length > 2)
			{
				_colorDal.Add(color);
				return new SuccessResult(Messages.ColorAdded);
			}
			else
			{
				return new ErrorResult(Messages.cantColor2char);
			}
		}

		public IResult Delete(Color color)
		{
			_colorDal.Delete(color);
			return new SuccessResult(Messages.ColorDeleted);
		}

		public IDataResult<List<Color>> GetAll()
		{
			return new DataResult<List<Color>>(_colorDal.GetAll(), true, Messages.HasBeenListed);
		}

		public IDataResult<Color> GetById(int colorID)
		{
			return new DataResult<Color>(_colorDal.Get(c => c.ColorID == colorID), true);
		}

		public IResult Update(Color color)
		{
			if (color.ColorName.Length > 2)
			{
				_colorDal.Update(color);
				return new SuccessResult();
			}
			else
			{
				return new ErrorResult(Messages.cantColor2char);
			}
		}
	}
}
