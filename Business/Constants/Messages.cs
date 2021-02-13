using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
	public static class Messages
	{
		public static string CarAdded = "Araba sisteme eklendi.";
		public static string CarDeleted = "Araba sistemden silindi.";
		public static string CarUpdated = "Araba güncellendi.";
		public static string BrandAdded = "Araba markası sisteme eklendi.";
		public static string BrandDelete = "Araba markası sistemden silindi";
		public static string ColorAdded = "Araba rengi sisteme eklendi.";
		public static string ColorDeleted = "Araba rengi sistemden silindi.";
		public static string cantBrand2char = "Araba markası en az 2 karakter içermelidir.";
		public static string cantCarName2char = "Araba markası en az 2 karakter içermelidir.";
		public static string cantColor2char = "Renk en az 2 karakter içermelidir.";
		public static string cantDailyPrice = "Günlük fiyat 0(Sıfır) TL'den az olamaz.";
		public static string UserException = "Bilgileriniz hatalıdır. Kontrol edip tekrar deneyiniz.(Adınız yada soyadınız az 2 harf içermeli, e-mail adresiniz en az 7 karakter içermeli, telefon numaranız 10 haneli olmalıdır.)";
		public static string UserAdded = "Sisteme kayıt oldunuz.";
		public static string UserDeleted = "Sistemden kaydınız silinmiştir.";
		public static string UserUpdated = "Kaydınız güncellenmiştir.";
		public static string ExceptionMessage = "Bir hata oluştu";
		public static string ThisCarCannotBeRent = "Bu araç müşteride olduğu için kiralanamaz.";
		public static string CarHasBeenDelivered = "Araç teslim edilmiştir.";

	}
}
