using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Abstract
{
	public interface ICarImageService
	{
        IDataResult<List<CarImage>> GetAll();

        IDataResult<CarImage> Get(int id);

        IResult Add(CarImagesOperationDto carImagesOperationDto);

        IResult Update(CarImagesOperationDto carImagesOperationDto);

        IResult Delete(CarImage entity);

        IDataResult<List<CarImage>> GetAllByCarId(int carId);

    }
}
