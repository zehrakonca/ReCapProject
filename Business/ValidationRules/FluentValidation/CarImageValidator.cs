using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
	public class CarImageValidator :AbstractValidator<CarImage>
	{
		public CarImageValidator()
		{
			RuleFor(c => c.CarID).NotNull();
			RuleFor(c => c.ImagePath).NotNull();
		}
	}
}
