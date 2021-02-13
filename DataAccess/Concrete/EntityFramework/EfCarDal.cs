using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
	{
		public List<CarDetailDto> GetCarDetails()
		{
			using (CarContext context = new CarContext())
			{
				var result = from cA in context.Cars
							 join cO in context.Colors
							 on cA.ColorID equals cO.ColorID
							 join b in context.Brands
							 on cA.BrandID equals b.BrandID
							 select new CarDetailDto
							 {
								 CarID = cA.CarID,
								 BrandName = b.BrandName,
								 ColorName = cO.ColorName,
								 DailyPrice = cA.DailyPrice,
								 Description = cA.Description,
								 ModelYear = cA.ModelYear
							 };
				return result.ToList();
			}
		}
	}
}
