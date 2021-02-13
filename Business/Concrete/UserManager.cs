using Business.Abstract;
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
	public class UserManager : IUserService
	{
		IUserDal _userDal;
		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}
		public IResult Add(User user)
		{
			if (user.UserName.Length > 1 || user.UserSurname.Length>1 || user.UserMail.Length >7 || user.UserTelephone.Length > 10)
			{
				_userDal.Add(user);
				return new SuccessResult(Messages.UserAdded);
			}
			else
			{
				
				return new ErrorResult(Messages.UserException);
			}
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

		public IDataResult<User> GetById(int userID)
		{
			return new DataResult<User>(_userDal.Get(u => u.UserID == userID), true);
		}

		public IResult Update(User user)
		{
			if (user.UserName.Length > 1 || user.UserSurname.Length > 1 || user.UserMail.Length > 7 || user.UserTelephone.Length > 10)
			{
				_userDal.Update(user);
				return new SuccessResult(Messages.UserUpdated);
			}
			else
			{
				return new ErrorResult(Messages.UserException);
			}
		}
	}
}
