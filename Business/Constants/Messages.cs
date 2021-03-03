using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
		public static string HasBeenListed = "Listelendi.";
		public static string WrongValidationType = "Bu bir doğrulama sınıfı değildir.";

		public static object FileNotCreated = "Dosya oluşturulamadı.";

		public static string ImagesHasBeenAdded = "Resim kaydedildi, yol oluşturuldu.";

		public static string CantLoadImage = "Sistemde 5 tane resim olduğundan dolayı resim yüklenemez.";
		public static string ImageAdded = "Resim eklendi.";
		public static string ImageDeleted = "Resim silindi.";
		public static string AuthorizationDenied = "Yetkilendirme reddedildi.";

		public static string AccessTokenCreated = "Hesap oluşturuldu.";
		public static string UserAlreadyExists = "Bu kullanıcı zaten sistemde kayıtlı.";
		public static string UserNotFound = "Kullanıcı bulunamadı";
		public static string IncorrectPassword = "Parola yanlış";
		public static string SuccessfulLogin = "Giriş başarılı";
		public static string UserRegistered = "Kayıt başarılı";
	}
}
