using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetCarDetail();
            //GetCarsByBrandId()
            //GetAll();
            //Add();
            //UpdateTest();
            //DeleteTest();

            //ColorGetAllTest();
            //ColorAddTest();
            //ColorDeleteTest();
            //ColorUpdateTest();


            //NewMethod();

            //Delete();

            // RentalAdd();

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer {UserId = 1, CompanyName= "Gökkas" });
            var result = customerManager.GetAll();
            foreach (var customer in result.Data)
            {
                Console.WriteLine(customer.CustomerId + " / " + customer.UserId + " / " + customer.CompanyName);
            }

        }
        private static void ColorAddTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Siyah" });
            var result = colorManager.GetAll();
             foreach (var color in result.Data)
             {
                Console.WriteLine(color.ColorName);
             }
        }

        private static void ColorDeleteTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Delete(new Color { ColorId = 2, ColorName = "Kırmızı" });

            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }


        private static void RentalAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental
            {
                CarId = 1,
                CustomerId = 3,
                RentDate = new DateTime(2021, 12, 12)

            });
            Console.WriteLine(result.Success);
            Console.WriteLine(result.Message);
        }

        //private static void Delete()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    userManager.Delete(new User
        //    {
        //        Id = 1005,
        //        FirstName = "Berivan",
        //        LastName = "Akkurt",
        //        Email = "berivanakkurt@gmail.com",
               



        //    });
        //}

        private static void NewMethod()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User
            {
                FirstName = "Şehnaz",
                LastName = "Akkurt",
                Email = "sehnazakkurt@gmail.com",
               
            });
        }

        private static void Add()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                
                CarName = "BCY",
                BrandId = 10,
                ColorId = 9,
                DailyPrice = 76,
                Description = "OPX",
                ModelYear = "2019"
            });
          
        }
        private static void ColorUpdateTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(new Color { ColorId = 3, ColorName = "Beyaz" });
            //foreach (var color in colorManager.GetAll())
            {
            //    Console.WriteLine(color.ColorName);
            }
        }

      
      

        private static void ColorGetAllTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
           // foreach (var color in colorManager.GetAll())
            //{
              //  Console.WriteLine(color.ColorName);
           // }
        }

        private static void DeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car
            {
                CarId = 5,
                CarName = "toyota 2",
                BrandId = 7,
                ColorId = 5,
                DailyPrice = 35,
                Description = "yeni araba2",
                ModelYear = "2023"
            });
            //foreach (var car in carManager.GetAll())
            {
               // Console.WriteLine(car.CarName);
            }
        }

        private static void UpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car
            {
                CarId = 5,
                CarName = "toyota 2",
                BrandId = 7,
                ColorId = 5,
                DailyPrice = 35,
                Description = "yeni araba2",
                ModelYear = "2023"
            });
           // foreach (var car in carManager.GetAll())
            {
               // Console.WriteLine(car.CarName);
            }
        }

       

        private static void GetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var rentals = carManager.GetAll();
            Console.WriteLine(rentals);
        }

        private static void GetCarsByBrandId()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //foreach (var car in carManager.GetCarsByBrandId(1))
            {
              //  Console.WriteLine(car.ModelYear);
            }
        }

        private static void GetCarDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                    {
                    Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName);
                }
                
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}

                                        