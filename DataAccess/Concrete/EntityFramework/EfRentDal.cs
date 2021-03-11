using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentDal : EfEntityRepositoryBase<Rental,CarContext>, IRentDal
    {

		public List<RentalDetailDto> GetAllRentalDetails(Expression<Func<Rental, bool>> filter = null)
		{
            using (CarContext context = new CarContext())
            {
                var result =
                    from rental in filter == null ? context.Rentals : context.Rentals.Where(filter)
                    join customer in context.Customers
                        on rental.CustomerID equals customer.CustomerID
                    join user in context.Users
                         on customer.UserID equals user.UserID
                    join car in context.Cars
                         on rental.CarID equals car.CarID
                    join brand in context.Brands
                         on car.BrandID equals brand.BrandID
                    join color in context.Colors
                         on car.ColorID equals color.ColorID
                    select new RentalDetailDto
                    {
                        RentDate = (DateTime)rental.RentDate,
                        ReturnDate = rental.ReturnDate,
                        RentalID = rental.RentalID,
                        BrandName = brand.BrandName,
                        CarDesctiption = car.Description,
                        ColorName = color.ColorName,
                        CompanyName = customer.CompanyName,
                        DailyPrice = car.DailyPrice,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        ModelYear = car.ModelYear
                    };

                return result.ToList();
            }
        }
	}
}