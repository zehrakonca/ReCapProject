using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using Business.Constants;
using Core.Constants;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        private readonly ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        //[ValidationAspect(typeof(CarImagesOperationDtoValidator))]
        public IResult Add(CarImagesOperationDto carImagesOperationDto)
        {
            var result = BusinessRules.Run(
                CheckCarImageCount(carImagesOperationDto.CarId),
                CheckIfCarId(carImagesOperationDto.CarId));
            if (result != null)
            {
                return result;
            }

            foreach (var file in carImagesOperationDto.Images)
            {
                _carImageDal.Add(new CarImage
                {
                    CarID = carImagesOperationDto.CarId,
                    ImagePath = FileProcessHelper.Upload(DefaultNameOrPath.ImageDirectory, file).Data
                });
            }

            return new SuccessResult(Messages.ImagesHasBeenAdded);
        }

        public IResult Delete(CarImage entity)
        {
            var imageData = _carImageDal.Get(p => p.ImageID == entity.ImageID);
            FileProcessHelper.Delete(imageData.ImagePath);
            _carImageDal.Delete(imageData);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.ImageID == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        //[ValidationAspect(typeof(CarImagesOperationDtoValidator))]
        public IResult Update(CarImagesOperationDto carImagesOperationDto)
        {
            foreach (var file in carImagesOperationDto.Images)
            {
                var result = BusinessRules.Run(
                    CheckIfCarImagesId(carImagesOperationDto.Id),
                    CheckCarImageCount(carImagesOperationDto.CarId),
                    CheckIfCarId(carImagesOperationDto.CarId)
                );
                if (result != null)
                {
                    return result;
                }

                FileProcessHelper.Delete(_carImageDal.Get(p => p.ImageID == carImagesOperationDto.Id).ImagePath);
                _carImageDal.Update(new CarImage
                {
                    ImageID = carImagesOperationDto.Id,
                    CarID = carImagesOperationDto.CarId,
                    ImagePath = FileProcessHelper.Upload(DefaultNameOrPath.ImageDirectory, file).Data
                });
            }

            return new SuccessResult(Messages.EditCarImageMessage);
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarId(carId));
            if (result != null)
            {
                return (IDataResult<List<CarImage>>)result;
            }

            var getAllbyCarIdResult = _carImageDal.GetAll(p => p.CarID == carId);
            if (getAllbyCarIdResult.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage>
                {
                    new CarImage
                    {
                        ImageID = -1,
                        CarID = carId,
                        Date = DateTime.MinValue,
                        ImagePath = DefaultNameOrPath.NoImagePath
                    }
                });
            }

            return new SuccessDataResult<List<CarImage>>(getAllbyCarIdResult);
        }

        #region Car Image Business Rules

        private IResult CheckCarImageCount(int carId)
        {
            if (_carImageDal.GetAll(p => p.CarID == carId).Count > 4)
            {
                return new ErrorResult(Messages.AboveImageAddingLimit);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarImagesId(int Id)
        {
            if (_carImageDal.Get(p => p.ImageID == Id) == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarId(int carId)
        {
            if (!_carService.GetByID(carId).Success)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.GetErrorCarMessage);
            }

            return new SuccessDataResult<List<CarImage>>();
        }
    }
    #endregion Car Image Business Rules
}
