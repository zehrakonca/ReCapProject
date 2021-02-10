using Business.Abstract;
using Business.Concrete;
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
			Color color = new Color();
			Car car = new Car();
			Brand brand = new Brand();
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
							Console.WriteLine("Bir hata oluştu.");
						}
						break;
					case 2:
						try
						{
							GetColor();
							int colorID = Convert.ToInt32(Console.ReadLine());
								Console.WriteLine($"Filtreye uyan araçlar: \nId\tAraç Rengi\tModel\tÇıkış Yılı\tGünlük Fiyat\tAçıklama");
								foreach (var cars in carManager.GetAllByColorID(colorID))
								{
									Console.WriteLine($"{car.CarID}\t{colorManager.GetById(car.ColorID).ColorName}\t{brandManager.GetById(car.BrandID).BrandName}\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
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
							int colorID = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine($"Filtreye uyan araçlar: \nId\tAraç Rengi\tModel\tÇıkış Yılı\tGünlük Fiyat\tAçıklama");
							foreach (var cars in carManager.GetAllByColorID(colorID))
							{
								Console.WriteLine($"{cars.CarID}\t{colorManager.GetById(cars.ColorID).ColorName}\t{brandManager.GetById(cars.BrandID).BrandName}\t{cars.ModelYear}\t\t{cars.DailyPrice}\t\t{cars.Description}");
							}
						}
						catch
						{
							Console.WriteLine("Bir hata oluştu.");
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
							foreach (var cars in carManager.GetByDailyPrice(dailyPrice1, dailyPrice2))
							{
								Console.WriteLine($"{colorManager.GetById(cars.ColorID).ColorName}\t" +
											      $"{brandManager.GetById(cars.BrandID).BrandName}\t{cars.ModelYear}\t" +
												  $"\t{cars.DailyPrice}\t\t{cars.Description}");
							}
							break;

						}
						catch
						{
							Console.WriteLine("Bir hata oluştu.");
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
							CarDetail();

						}
						catch
						{
							Console.WriteLine("Bir hata oluştu.");
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
							Console.WriteLine("Bir hata oluştu.");
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
							Console.WriteLine("Bir hata oluştu.");
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
							Console.WriteLine("Bir hata oluştu.");
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
							Console.WriteLine("Bir hata oluştu.");
						}
						break;


				}
			}
			Console.ReadLine();
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
							  " 7 - Silme işlemleri (7)\n"+
							  " 8 - Sisteme yeni renk ekle (8)\n"+
							  " 9 - Sisteme yeni marka ekle (9)");
			Console.WriteLine("__________________________________________________________________");
		}
		private static void GetColor()
		{
			ColorManager colorManager = new ColorManager(new EfColorDal());
			Console.WriteLine("Sistemdeki renkler : \n ID\t Renk");
			foreach (var color in colorManager.GetAll())
			{
				Console.WriteLine($"{color.ColorID}\t{color.ColorName}");
			}
		}
		private static void GetBrand()
		{
			BrandManager brandManager = new BrandManager(new EfBrandDal());
			Console.WriteLine("Sistemdeki markalar : \n ID\t Marka");
			foreach (var brand in brandManager.GetAll())
			{
				Console.WriteLine($"{brand.BrandID}\t{brand.BrandName}");
			}
		}

		private static void CarDetail()
		{
			CarManager carManager = new CarManager(new EfCarDal());
			Console.WriteLine("Sistemdeki bütün arabalar: \nId\tAraç Rengi\tModel\t\tÇıkış Yılı\tGünlük Fiyat\tAçıklama");
			foreach (var car in carManager.GetCarDetails())
			{
				Console.WriteLine($"{car.CarID}\t{car.ColorName}\t{car.BrandName}\t\t" +
					              $"{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
			}
		}
	}
}
