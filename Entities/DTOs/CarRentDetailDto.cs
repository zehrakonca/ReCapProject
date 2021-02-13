using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
	public class CarRentDetailDto : IDto
	{
		public int RentID { get; set; }
		public int CarID { get; set; }
		public string UserName { get; set; }
		public string UserSurname { get; set; }
		public string UserTelephone { get; set; }
		public DateTime RentDate { get; set; }
		public DateTime ReturnDate { get; set; }
	}
}
