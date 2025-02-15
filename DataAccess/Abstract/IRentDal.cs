﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
	public interface IRentDal : IEntityRepository<Rental>
	{
		List<RentalDetailDto> GetAllRentalDetails(Expression<Func<Rental, bool>> filter = null);
	}
}
