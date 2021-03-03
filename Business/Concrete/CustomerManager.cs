using Business.Abstract;
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
	public class CustomerManager : ICustomerService
	{
		ICustomerDal _customerDal;
		public CustomerManager(ICustomerDal customerDal)
		{
			_customerDal = customerDal;
		}
		[SecuredOperation("Admin")]
		[ValidationAspect(typeof(CustomerValidator))]
		public IResult Add(Customer customer)
		{
			_customerDal.Add(customer);
			return new SuccessResult(Messages.UserAdded);
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

		[ValidationAspect(typeof(CustomerValidator))]
		public IResult Update(Customer customer)
		{
			_customerDal.Update(customer);
			return new SuccessResult();
		}
	}
}
