using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			CarManager carManager = new CarManager(new EfCarDal());
			BrandManager brandManager = new BrandManager(new EfBrandDal());
			ColorManager colorManager = new ColorManager(new EfColorDal());
			UserManager userManager = new UserManager(new EfUserDal());
			CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
			RentalManager rentalManager = new RentalManager(new EfRentDal());
			Color color = new Color();
			Car car = new Car();
			Brand brand = new Brand();
			Customer customer= new Customer();
			Rental rental = new Rental();
			User user = new User(); ;
			Console.WriteLine("Araç kiralama sistemine hoşgeldin.\n" +
							  "Bu sistemde yapabileğin işlemler aşağıda sıralanmıştır.\n" +
							  "Seçeceğin işlem için gösterilen rakamı tuşlarsan, işleme ulaşabilirsin.");

			while (true)
			{
				Welcome();
				int choice = Convert.ToInt32(Console.ReadLine());
				switch (choice)
				{
					case 1:
						try
						{
							CarDetail();
						}
						catch
						{
							Console.WriteLine(Messages.ExceptionMessage);
						}
						break;
					case 2:
						try
						{
							GetColor();
							int colorID = Convert.ToInt32(Console.ReadLine());
							var resultColor = carManager.GetAllByColorID(colorID);
								Console.WriteLine($"Filtreye uyan araçlar: \nId\tAraç Rengi\tModel\tÇıkış Yılı\tGünlük Fiyat\tAçıklama");
								foreach (var cars in resultColor.Data)
								{
									Console.WriteLine($"{car.CarID}\t{color.ColorName}\t{brand.BrandName}\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
								}	
						}
						catch
						{
							Console.WriteLine("Bir hata oluştu.");
						}
						break;
					case 3:
						try
						{
							GetBrand();
							int brandID = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine($"Filtreye uyan araçlar: \nId\tAraç Rengi\tModel\tÇıkış Yılı\tGünlük Fiyat\tAçıklama");
							var resultBrand = carManager.GetAllByBrandID(brandID);
							foreach (var cars in resultBrand.Data)
							{
								Console.WriteLine($"{cars.CarID}\t{color.ColorName}\t{brand.BrandName}\t{cars.ModelYear}\t\t{cars.DailyPrice}\t\t{cars.Description}");
							}
						}
						catch
						{
							Console.WriteLine(Messages.ExceptionMessage);
						}
						break;
					case 4:
						try
						{
							Console.WriteLine("Minimum günlük kullanım ücretini giriniz : ");
							decimal dailyPrice1 = Convert.ToDecimal(Console.ReadLine());
							Console.WriteLine("Maksimum günlük kullanım ücretini giriniz : ");
							decimal dailyPrice2 = Convert.ToDecimal(Console.ReadLine());
							Console.WriteLine("Belirttiğiniz ücret aralığındaki arabalar : \n\tAraç Rengi\tModel\t" +
											  "Çıkış Yılı\tGünlük Fiyat\tAçıklama ");
							var resultPrice = carManager.GetByDailyPrice(dailyPrice1, dailyPrice2);
							foreach (var cars in resultPrice.Data)
							{
								Console.WriteLine($"{cars.CarID}\t{color.ColorName}\t{brand.BrandName}\t{cars.ModelYear}\t\t{cars.DailyPrice}\t\t{cars.Description}");
							}
							break;

						}
						catch
						{
							Console.WriteLine(Messages.ExceptionMessage);
						}
						break;
					case 5:
						try
						{
							Console.WriteLine("Ekleyecek olduğunuz arabanın bilgilerini giriniz: ");
							GetBrand();
							Console.WriteLine("Marka no'sunu giriniz :");
							int brandId = Convert.ToInt32(Console.ReadLine());
							GetColor();
							Console.WriteLine("Renk no'sunu giriniz: ");
							int colorId = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("Aracın çıkış yılını(model yılı) giriniz: ");
							int modelYear = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("Aracın günlük ücretini giriniz:");
							decimal dailyPrice = Convert.ToDecimal(Console.ReadLine());
							Console.WriteLine("Araç açıklamasını giriniz:");
							string description = Console.ReadLine();
							carManager.Add(new Car
							{
								BrandID = brandId,
								ColorID = colorId,
								ModelYear = modelYear,
								DailyPrice = dailyPrice,
								Description = description

							});
							Console.WriteLine(Messages.CarAdded);
							CarDetail();
							break;
						}
						catch
						{
							Console.WriteLine(Messages.ExceptionMessage);
						}
						break;
					case 6:
						try
						{
							Console.WriteLine("Güncellenmek istenen arabanın IDsini giriniz:");
							CarDetail();
							int carId = Convert.ToInt32(Console.ReadLine());
							GetBrand();
							Console.WriteLine("Marka no'sunu giriniz :");
							int brandId = Convert.ToInt32(Console.ReadLine());
							GetColor();
							Console.WriteLine("Renk no'sunu giriniz: ");
							int colorId = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("Aracın çıkış yılını(model yılı) giriniz: ");
							int modelYear = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("Aracın günlük ücretini giriniz:");
							decimal dailyPrice = Convert.ToDecimal(Console.ReadLine());
							Console.WriteLine("Araç açıklamasını giriniz:");
							string description = Console.ReadLine();
							carManager.Update(new Car
							{
								CarID = carId,
								BrandID = brandId,
								ColorID = colorId,
								ModelYear = modelYear,
								DailyPrice = dailyPrice,
								Description = description
							});
							CarDetail();
							break;
						}
						catch
						{
							Console.WriteLine(Messages.ExceptionMessage);
						}
						break;
					case 7:
						try
						{
							CarDetail();
							Console.WriteLine("Silmek istediğiniz aracın ID'sini giriniz : ");
							int carID = Convert.ToInt32(Console.ReadLine());
							carManager.Delete(new Car { CarID = carID });
							CarDetail();
						}
						catch
						{
							Console.WriteLine(Messages.ExceptionMessage);
						}
						break;
					case 8:
						try
						{
							GetColor();
							Console.WriteLine("Ekleyeceğiniz renk bilgilerini giriniz :");
							string colorName = Console.ReadLine();
							colorManager.Add(new Color { ColorName = colorName });
							GetColor();
						}
						catch
						{
							Console.WriteLine(Messages.ExceptionMessage);
						}
						break;
					case 9:
						try
						{
							GetBrand();
							Console.WriteLine("Ekleyeceğiniz marka bilgilerini giriniz :");
							string brandName = Console.ReadLine();
							brandManager.Add(new Brand {BrandName = brandName});
							GetBrand();
						}
						catch
						{
							Console.WriteLine(Messages.ExceptionMessage);
						}
						break;
					case 10:
						try
						{
							Console.WriteLine("Adını giriniz :");
							string Name = Console.ReadLine();
							Console.WriteLine("Soyadını giriniz: ");
							string Surname = Console.ReadLine();
							Console.WriteLine("Mail adresini giriniz : ");
							string Mail = Console.ReadLine();
							Console.WriteLine("Telefon numarasını giriniz :  ");
							string Telephone = Console.ReadLine();
							Console.WriteLine("Parola giriniz: ");
							string Password = Console.ReadLine();
							userManager.Add(new User
							{
								UserName = Name,
								UserSurname = Surname,
								UserMail = Mail,
								UserTelephone = Telephone,
								UserPassword = Password
							});
							Console.WriteLine(Messages.UserAdded);
						}
						catch
						{
							Console.WriteLine(Messages.ExceptionMessage);
						}
						break;
					case 11:
						try
						{
							UserDetail();
							Console.WriteLine("Sisteme kayıt edeceğiniz müşterinin ID'sini girin: ");
							int userID = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("Şirket (eğer varsa) adını giriniz: ");
							string companyName = Console.ReadLine();
							customerManager.Add(new Customer
							{
								UserID = userID,
								CompanyName = companyName
							});
							Console.WriteLine(Messages.UserAdded);
						}
						catch
						{
							Console.WriteLine(Messages.ExceptionMessage);
						}
						break;
					case 12:
						try
						{
							UserDetail();
						}
						catch
						{
							Console.WriteLine(Messages.ExceptionMessage);
						}
						break;
					case 13:
						try
						{
							CarDetail();
							Console.WriteLine("Kiralanmak istenen aracın ID'sini giriniz : ");
							int carID = Convert.ToInt32(Console.ReadLine());
							CustomerDetail();
						    Console.WriteLine("Kiralamak isteyen müşterinin IDsini giriniz: ");
							int customerID = Convert.ToInt32(Console.ReadLine());
							rentalManager.Add(new Rental
							{
								 CustomerID = customerID,
								 CarID = carID,
								 RentDate = DateTime.Now
							});
						}
						catch
						{
							Console.WriteLine(Messages.ExceptionMessage);
						}
						break;
					case 14:
						try
						{
							RentDetail();
						}
						catch
						{
							Console.WriteLine(Messages.ExceptionMessage);
						}
						break;
					case 15:
						try
						{
							RentDetail();
							Console.WriteLine("Teslim alınacak aracın ID'sini giriniz: ");
							int carID= Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("Teslim alınacak müşterinin ID'sini giriniz:");
							int customerID = Convert.ToInt32(Console.ReadLine());
							rentalManager.Update(new Rental
							{
								CarID = carID,
								CustomerID = customerID,
								ReturnDate = DateTime.Now
							}) ;
							Console.WriteLine(Messages.CarUpdated);
							Console.WriteLine(Messages.CarHasBeenDelivered);
						}
						catch
						{
							Console.WriteLine(Messages.ExceptionMessage);
						}
						break;
				}
			}
			//Console.ReadLine();
		}
		private static void Welcome()
		{
			Console.WriteLine("__________________________________________________________________");
			Console.WriteLine(" 1 - Sistemdeki bütün araçları listele (1)\n" +
							  " 2 - Sistemdeki belirtilen bir renkteki araçları listele (2)\n" +
							  " 3 - Sistemdeki belirtilen modeldeki araçları listele (3)\n" +
							  " 4 - Belirtilen ücret aralığındaki araçları listele (4)\n" +
							  " 5 - Sisteme yeni araç ekle (5)\n" +
							  " 6 - Güncelleme işlemleri (6)\n" +
							  " 7 - Silme işlemleri (7)\n" +
							  " 8 - Sisteme yeni renk ekle (8)\n" +
							  " 9 - Sisteme yeni marka ekle (9)\n" +
							  "10 - Sisteme kullanıcı kaydet (10)\n" +
							  "11 - Sisteme müşteri kaydet (11)\n" +
						      "12 - Sistemdeki kullanıcıları gör (12)\n" +
							  "13 - Araç Kirala (13)\n" +
							  "14 - Kiralanmış Arabaları Gör (14)\n" +
							  "15 - Aracı Teslim Al (15)");
			Console.WriteLine("__________________________________________________________________");
		}
		private static void GetColor()
		{
			ColorManager colorManager = new ColorManager(new EfColorDal());
			var result = colorManager.GetAll();
			Console.WriteLine("Sistemdeki renkler : \n ID\t Renk");
				foreach (var color in result.Data)
				{
					Console.WriteLine($"{color.ColorID}\t{color.ColorName}");
				}
		}
		private static void GetBrand()
		{
			BrandManager brandManager = new BrandManager(new EfBrandDal());
			var result = brandManager.GetAll();
			Console.WriteLine("Sistemdeki markalar : \n ID\t Marka");
				foreach (var brand in result.Data)
				{
					Console.WriteLine($"{brand.BrandID}\t{brand.BrandName}");
				}
		}

		private static void CarDetail()
		{
			CarManager carManager = new CarManager(new EfCarDal());
			var result = carManager.GetCarDetails();
			Console.WriteLine("Sistemdeki bütün arabalar: \nId\tAraç Rengi\tModel\t\tÇıkış Yılı\tGünlük Fiyat\tAçıklama");
				foreach (Entities.DTOs.CarDetailDto car in result.Data)
				{
					Console.WriteLine($"{car.CarID}\t{car.ColorName}\t{car.BrandName}\t\t" +
									  $"{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
				}
		}
		private static void UserDetail()
		{
			UserManager userManager = new UserManager(new EfUserDal());
			var result = userManager.GetAll();
			Console.WriteLine("Sistemde kayıtlı kullanıcılar : \nId\tAdı\tSoyadı\tTelefon\t\tMail\t");
			foreach (var user in result.Data)
			{
				Console.WriteLine($"{user.UserID}\t{user.UserName}\t{user.UserSurname}\t{user.UserTelephone}\t{user.UserMail}");
			}
		}
		private static void CustomerDetail()
		{
			CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
			var result = customerManager.GetCustomer();
			Console.WriteLine("Sistemdeki kayıtlı müşteriler : \nMüşteri Numarası\tKŞirket Adı");
			foreach (var customer in result.Data)
			{
				Console.WriteLine($"{customer.CustomerID}\t{customer.CompanyName}");
			}
		}
		private static void RentDetail()
		{
			RentalManager rentalManager = new RentalManager(new EfRentDal());
			Rental rental = new Rental();
			var result = rentalManager.GetRentCarDetails();
			Console.WriteLine("Kiralık verilmiş arabalar ve müşteri bilgileri :\n ID\tAraba No\t" +
				              " Kişi Adı\tKişi Soyadı\tTelefonu\tAlınan tarih\tTeslim tarihi ");
				foreach (var customer in result.Data)
				{
					Console.WriteLine($"{customer.RentID}\t{customer.CarID}\t{customer.UserName}\t" +
									  $" {customer.UserSurname}\t{customer.UserTelephone}\t{customer.RentDate}\t{customer.ReturnDate}");
				}
		}
	}
}
