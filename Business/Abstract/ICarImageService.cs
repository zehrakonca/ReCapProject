using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface ICarImageService
	{
		IResult Add(IFormFile file, CarImage image);
		IResult Update(IFormFile file, CarImage image);
		IResult Delete(CarImage image);
		IDataResult<CarImage> GetByID(int carID);
		IDataResult<List<CarImage>> GetListImage();

	}
}
