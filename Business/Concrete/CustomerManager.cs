﻿using Business.Abstract;
using Business.Constants;
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
	public class CustomerManager : ICustomerService
	{
		ICustomerDal _customerDal;
		public CustomerManager(ICustomerDal customerDal)
		{
			_customerDal = customerDal;
		}
		public IResult Add(Customer customer)
		{
			if (customer.CompanyName.Length > 3)
			{
				_customerDal.Add(customer);
				return new SuccessResult(Messages.UserAdded);
			}
			else
			{
				return new ErrorResult(Messages.ExceptionMessage);
			}
		}

		public IResult Delete(Customer customer)
		{
			_customerDal.Delete(customer);
			return new SuccessResult();
		}

		public IDataResult<Customer> GetByID(int id)
		{
			return new DataResult<Customer>(_customerDal.Get(c => c.CustomerID == id), true);
		}

		public IDataResult<List<Customer>> GetCustomer()
		{
			return new DataResult<List<Customer>>(_customerDal.GetAll(), true);
		}

		public IResult Update(Customer customer)
		{
			_customerDal.Update(customer);
			return new SuccessResult();
		}
	}
}
