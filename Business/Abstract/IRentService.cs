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
		IResult DeliverTheCar(Rental rent); //aracı teslim al.

		IDataResult<List<RentalDetailDto>> GetAllRentalDetails(); //kiralanan kiralanmayan bütün araçlar
		IDataResult<List<RentalDetailDto>> GetAllUndeliveredRentalDetails(); // teslim alınmayan araçlar
		IDataResult<List<RentalDetailDto>> GetAllDeliveredRentalDetails(); // teslim alınan araçlar
		IDataResult<List<Rental>> GetAll();
		IDataResult<Rental> Get(int rentID);
	}
}
