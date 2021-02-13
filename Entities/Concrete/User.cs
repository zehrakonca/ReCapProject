using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class User : IEntity
	{
		public int UserID { get; set; }
		public string UserName { get; set; }
		public string UserSurname { get; set; }
		public string UserMail { get; set; }
		public string UserPassword { get; set; }
		public string UserTelephone { get; set; }
	}
}
