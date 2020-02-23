using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_Quality_and_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Driver driver = new Driver();

            GetCarValue(driver);

            Console.WriteLine("\n");

            GetAge(driver);

            Console.WriteLine("\n");

            GetCoverType(driver);

            Console.WriteLine("\n");

            GetPenaltyPoints(driver);

            Console.WriteLine("\n");

            Console.ReadKey();
        }

        public static void SelectCoverType(string inputCover, Driver driver)
        {
            if (inputCover == "0")
            {
                driver.CoverKind = Cover.ThirdParty;
            }
            else if (inputCover == "1")
            {
                driver.CoverKind = Cover.Comprehensive;
            }
        }

        public static void GetAge(Driver driver)
        {
            Console.Write($"Please enter your age: ");

            driver.Age = int.Parse(Console.ReadLine());

            CalculatePremiumForAge(driver);
        }

        public static void GetCoverType(Driver driver)
        {
            Console.Write($"Please enter the type of cover you would like to select for the vehicle: 0.{Cover.ThirdParty} or 1.{Cover.Comprehensive}\nInput here: ");

            string coverType = Console.ReadLine();

            SelectCoverType(coverType, driver);

            CalculatePremiumForCoverType(driver);
        }

        public static void GetPenaltyPoints(Driver driver)
        {
            Console.Write("Enter the number of penalty points you have: ");

            driver.PenaltyPoints = int.Parse(Console.ReadLine());

            CalculatePenaltyPointCharge(driver);

            Console.WriteLine($"\nYour quote is: \u20AC{driver.CarValue}");
        }

        public static void GetCarValue(Driver driver)
        {
            Console.WriteLine("Hello. Welcome to Sligo Insurance. We just need to get a few details for you in order to give you a valid quote.\n");

            Console.Write("Please enter the value of the car you want to insure: \u20AC");

            driver.CarValue = float.Parse(Console.ReadLine());
        }

        public static float CalculatePenaltyPointCharge(Driver driver)
        {
            switch (driver.PenaltyPoints)
            {
                case int n when n == 0:
                    driver.CarValue += 0;
                    break;

                case int n when (n >= 1 && n <= 4):
                    driver.CarValue += 100.00f;
                    break;

                case int n when (n >= 5 && n <= 7):
                    driver.CarValue += 100.00f;
                    break;

                case int n when (n >= 8 && n <= 10):
                    driver.CarValue += 100.00f;
                    break;

                case int n when (n >= 11 && n <= 12):
                    driver.CarValue += 100.00f;
                    break;

                default:
                    Console.WriteLine("No quote possible");
                    break;
            }

            return driver.CarValue;
        }

        public static float CalculatePremiumForCoverType(Driver driver)
        {
            switch (driver.CoverKind)
            {
                case Cover.ThirdParty:
                    driver.CarValue += driver.CarValue * 1.25f;
                    break;
                case Cover.Comprehensive:
                    driver.CarValue += driver.CarValue * 1.4f;
                    break;
                default:
                    break;
            }

            return driver.CarValue;
        }

        public static float CalculatePremiumForAge(Driver driver)
        {
            switch (driver.Age)
            {
                case int n when n < 18:
                    Console.WriteLine("\nNo quote Possible!");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;

                case int n when n >= 18 && n <= 25:
                    driver.CarValue += driver.CarValue * 1.10f;
                    break;
                default:
                    break;
            }

            return driver.CarValue;
        }
    }
}
