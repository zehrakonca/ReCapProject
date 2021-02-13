using Core.Utilities.Results.Abstact;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
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
		IDataResult<List<CarRentDetailDto>> GetRentCarDetails();
	}
}
