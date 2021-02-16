using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();
            //CarDtoTest();
            //CarAddTest();
            //UserDtoTest();
        }

        private static void UserDtoTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var u in userManager.GetUserDetailDtos().Data)
            {
                Console.WriteLine(u.UserId + " " + u.FirstName + " " + u.LastName + " " + u.Password + " " + u.Email + " " + u.CompanyName);

            }
            Console.WriteLine(userManager.GetUserDetailDtos().Message);
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car
            {
                BrandId = 2,
                //CarId=9,
                CarName = "Honda",
                ColorId = 3,
                DailyPrice = 30,
                Description = "Hasarlı",
                ModelYear = 2021
            });
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);

            }
            Console.WriteLine(result.Message);
        }

        private static void CarDtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetailDtos();
            if (result.Success)
            {
                foreach (var car in carManager.GetCarDetailDtos().Data)
                {
                    Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
                    Console.WriteLine(result.Message);

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var c in colorManager.GetAll().Data)
            {
                Console.WriteLine(c.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var b in brandManager.GetAll().Data)
            {
                Console.WriteLine(b.BrandName);
            }
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.ModelYear);
            }
        }
    }
}
