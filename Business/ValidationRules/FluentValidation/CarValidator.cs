﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
	public class CarValidator: AbstractValidator<Car>
	{
		public CarValidator()
		{
			RuleFor(c => c.DailyPrice).GreaterThan(0);
			RuleFor(c => c.BrandID).NotEmpty();
			RuleFor(c => c.ColorID).NotEmpty();
			RuleFor(c => c.DailyPrice).NotEmpty();
			RuleFor(c => c.ModelYear).NotEmpty();
		}
	}
}
