using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfRentDal : EfEntityRepositoryBase<Rental, CarContext>, IRentDal
	{
		public List<CarRentDetailDto> GetRentCarDetails()
		{
			using (CarContext context = new CarContext())
			{
				var result = from r in context.Rentals
							 join cA in context.Cars
							 on r.CarID equals cA.CarID
							 join c in context.Customers
							 on r.CustomerID equals c.CustomerID
							 join u in context.Users
							 on c.UserID equals u.UserID
 							 select new CarRentDetailDto
							 {
								 RentID = r.RentalID,
								 CarID = cA.CarID,
								 UserName = u.UserName,
								 UserSurname =u.UserSurname,
								 UserTelephone = u.UserTelephone,
								 RentDate = r.RentDate,
								 ReturnDate = r.ReturnDate
							 };
				return result.ToList();
			}
		}
	}
}
