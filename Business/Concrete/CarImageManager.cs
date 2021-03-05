using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Helpers;
using Business.BusinessAspect.Autofac;

namespace Business.Concrete
{
	public class CarImageManager : ICarImageService
	{
		ICarImageDal _carImageDal;
		public CarImageManager(ICarImageDal carImageDal)
		{
			_carImageDal = carImageDal;
		}
		//[SecuredOperation("Admin")]
		//[ValidationAspect(typeof(CarImageValidator))]
		public IResult Add(IFormFile file, CarImage image)
		{
			IResult result = BusinessRules.Run(CheckImageLimit(image.CarID));
			if(result!=null)
			{
				return result;
			}
			image.ImagePath = FileHelper.Add(file);
			image.Date = DateTime.Now;
			_carImageDal.Add(image);
			return new SuccessResult(Messages.ImageAdded);
		}
		[ValidationAspect(typeof(CarImageValidator))]
		public IResult Delete(CarImage image)
		{
			FileHelper.Delete(image.ImagePath);
			_carImageDal.Delete(image);
			return new SuccessResult(Messages.ImageDeleted);
		}

		[ValidationAspect(typeof(CarImageValidator))]
		public IDataResult<CarImage> GetByID(int carID)
		{
			return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.CarID == carID));
		}

		public IDataResult<List<CarImage>> GetListImage()
		{
			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
		}

		[ValidationAspect(typeof(CarImageValidator))]
		public IResult Update(IFormFile file, CarImage image)
		{
			image.ImagePath = FileHelper.Update(_carImageDal.Get(i => i.ImageID == image.ImageID).ImagePath, file);
			image.Date = DateTime.Now;
			_carImageDal.Update(image);
			return new SuccessResult();
		}
		private IResult CheckImageLimit(int carID)
		{
			var carImageCount = _carImageDal.GetAll(i => i.CarID == carID).Count;
			if(carImageCount>=5)
			{
				return new ErrorResult(Messages.CantLoadImage);
			}
			return new SuccessResult(Messages.ImagesHasBeenAdded);
		}
	}
}
