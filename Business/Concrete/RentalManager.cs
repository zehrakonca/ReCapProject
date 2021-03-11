using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentService
    {
        private readonly IRentDal _rentalDal;

        public RentalManager(IRentDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental entity)
        {
            var result = BusinessRules.Run(WillLeasedCarAvailable(entity.CarID));

            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<Rental> Get(int id)
        {
            Rental rental = _rentalDal.Get(p => p.RentalID == id);
            if (rental == null)
            {
                return new ErrorDataResult<Rental>(Messages.ExceptionMessage);
            }
            else
            {
                return new SuccessDataResult<Rental>(rental, Messages.HasBeenListed);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            List<Rental> rentals = _rentalDal.GetAll();
            if (rentals.Count == 0)
            {
                return new ErrorDataResult<List<Rental>>(Messages.GetErrorRentalMessage);
            }
            else
            {
                return new SuccessDataResult<List<Rental>>(rentals, Messages.HasBeenListed);
            }
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            List<RentalDetailDto> rentalDetailDtos = _rentalDal.GetAllRentalDetails();
            if (rentalDetailDtos.Count > 0)
                return new SuccessDataResult<List<RentalDetailDto>>(rentalDetailDtos, Messages.HasBeenListed);
            else
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.ExceptionMessage);
        }

        public IDataResult<List<RentalDetailDto>> GetAllUndeliveredRentalDetails()
        {
            List<RentalDetailDto> rentalDetailDtos = _rentalDal.GetAllRentalDetails(p => p.ReturnDate == null);
            if (rentalDetailDtos.Count > 0)
                return new SuccessDataResult<List<RentalDetailDto>>(rentalDetailDtos, Messages.HasBeenListed);
            else
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.ExceptionMessage);
        }

        public IDataResult<List<RentalDetailDto>> GetAllDeliveredRentalDetails()
        {
            List<RentalDetailDto> rentalDetailDtos = _rentalDal.GetAllRentalDetails(p => p.ReturnDate != null);
            if (rentalDetailDtos.Count > 0)
                return new SuccessDataResult<List<RentalDetailDto>>(rentalDetailDtos, Messages.HasBeenListed);
            else
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.ExceptionMessage);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult DeliverTheCar(Rental entity)
        {
            var result = BusinessRules.Run(CanARentalCarBeReturned(entity.RentalID));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.CarDeliverTheCar);
        }

        #region RentalManager Business Rules

        private IResult WillLeasedCarAvailable(int carId)
        {
            if (_rentalDal.Get(p => p.CarID == carId && p.ReturnDate == null) != null)
                return new ErrorResult(Messages.ExceptionMessage);
            else
                return new SuccessResult();
        }

        private IResult CanARentalCarBeReturned(int carId)
        {
            if (_rentalDal.Get(p => p.CarID == carId && p.ReturnDate == null) == null)
                return new ErrorResult(Messages.ExceptionMessage);
            else
                return new SuccessResult();
        }

        #endregion RentalManager Business Rules
    }
}