﻿using Core.Utilities.Results;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface IUserService
	{
		IResult Add(User user);
		IResult Update(User user);
		IResult Delete(User user);
		IDataResult<List<User>> GetAll();
		IDataResult<User> GetById(int userID);

		IDataResult<List<OperationClaim>> GetClaims(User user);

		User GetByEmail(string email);
	}
}
