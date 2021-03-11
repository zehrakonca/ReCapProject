using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Business.BusinessAspect.Autofac;

namespace Business.Concrete
{
	public class UserManager : IUserService
	{
		IUserDal _userDal;
		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}
		//[SecuredOperation("Admin")]
		[ValidationAspect(typeof(UserValidator))]
		public IResult Add(User user)
		{
			_userDal.Add(user);
			return new SuccessResult(Messages.UserAdded);
		}
		public IResult Delete(User user)
		{
			_userDal.Delete(user);
			return new SuccessResult(Messages.UserDeleted);
		}

		public IDataResult<List<User>> GetAll()
		{
			return new DataResult<List<User>>(_userDal.GetAll(), true);
		}

		public User GetByEmail(string email)
		{
			return _userDal.Get(u => u.Email == email);
		}

		public IDataResult<User> GetById(int userID)
		{
			return new DataResult<User>(_userDal.Get(u => u.UserID == userID), true);
		}

		public IDataResult<List<OperationClaim>> GetClaims(User user)
		{
			return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
		}

		[ValidationAspect(typeof(UserValidator))]
		public IResult Update(User user)
		{
			_userDal.Update(user);
			return new SuccessResult(Messages.UserUpdated);
		}
	}
}
