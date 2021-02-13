using Core.Utilities.Results.Abstact;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface ICustomerService
	{
		IResult Add(Customer customer);
		IResult Update(Customer customer);
		IResult Delete(Customer customer);
		IDataResult<List<Customer>> GetCustomer();
		IDataResult<Customer> GetByID(int id);
	}
}
