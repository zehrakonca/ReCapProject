﻿using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
	public class RentalValidator : AbstractValidator<Rental>
	{
		public RentalValidator()
		{
			RuleFor(r => r.CarID).NotEmpty();
			RuleFor(r => r.CustomerID).NotEmpty();
			RuleFor(r => r.RentDate).NotEmpty();
		}
	}
}
