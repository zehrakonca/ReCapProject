using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
	public interface IRentService
	{
		IResult Add(Rental rent);
		IResult Update(Rental rent);
		IResult Delete(Rental rent);
		IDataResult<List<Rental>> GetRentCar();
		IDataResult<Rental> GetByID(int id);
		IDataResult<List<CarRentDetailDto>> GetRentCarDetails(Expression<Func<Rental, bool>> filter = null);
	}
}
