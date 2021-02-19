using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
	public class UserValidator : AbstractValidator<User>
	{
		public UserValidator()
		{
			RuleFor(u => u.UserName).MinimumLength(2);
			RuleFor(u => u.UserSurname).MinimumLength(2);
			RuleFor(u => u.UserTelephone).MinimumLength(10);
			RuleFor(u => u.UserMail).EmailAddress();
			RuleFor(u => u.UserName).NotEmpty();
			RuleFor(u => u.UserSurname).NotEmpty();
			RuleFor(u => u.UserPassword).NotEmpty();
			RuleFor(u => u.UserMail).NotEmpty();
			RuleFor(u => u.UserTelephone).NotEmpty();
		}
	}
}
