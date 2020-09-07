using System;
using System.Dynamic;
using System.Globalization;

namespace SocialSecurityNumber__
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            string socialSecurityNumber;
            string generation = "";

            if (args.Length > 0) 
            {
                firstName = args[0];
                lastName = args[1];
                socialSecurityNumber = args[2];

            }
            else
            {
                Console.WriteLine("Please Enter Your Information");
                Console.WriteLine("FirtsName");
                firstName = Console.ReadLine();

                Console.WriteLine("Lastname");
                lastName = Console.ReadLine();

                Console.WriteLine("Social Security Number(YYYYMMDD-XXXX)");
                socialSecurityNumber = Console.ReadLine();
            }
            Console.Clear();

            string gender;

            int GenderNumber = int.Parse(socialSecurityNumber.Substring(socialSecurityNumber.Length - 2, 1));

            bool isFemale = GenderNumber % 2 == 0;

            gender = isFemale ? "Female" : "Male";

            DateTime birthDate = DateTime.ParseExact(socialSecurityNumber.Substring(0, 8), "yyyymmdd", CultureInfo.InvariantCulture);
            
            int age = DateTime.Now.Year - birthDate.Year;

            if ((birthDate.Month > DateTime.Now.Month) || (birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day))
            {
                age--;
            }
            const int SilentGenerationEnds = 1945;
            const int BabyBoomersEnds = 1964;
            const int GenerationXEnds = 1979;
            const int MillennialsEnds = 1995;
            const int GenerationZEnds = 2010;

            
            

                switch (birthDate.Year <= SilentGenerationEnds ? "SilentGeneration" :
                    birthDate.Year <= BabyBoomersEnds ? "Babyboomer" :
                    birthDate.Year <= GenerationXEnds ? "GenerationX" :
                    birthDate.Year <= MillennialsEnds ? "Millennial" :
                    birthDate.Year <= GenerationZEnds ? "GenerationZ" : "GenerationAlpha")
                {
                    case "SilentGeneration":
                        generation = "Silent Generation";
                        break;

                    case "BabyBoomeer":
                        generation = "Baby Bommer";
                        break;

                    case "GenerationX":
                        generation = "GenerationX";
                        break;

                    case "Millennial":
                        generation = "Millennial";
                        break;

                    case "GenerationZ":
                        generation = "GenerationZ";
                        break;
                }
            
            Console.WriteLine($"{"Name: ",-25}{firstName} {lastName}\n" +
               $"{"Social Security Number:",-25}{socialSecurityNumber}\n" +
               $"{"Gender:",-25}{gender}\n" +
               $"{"Age:",-25}{age}\n" +
              $"{"Generation:",-25}{generation}\n"); 
        }
    }
}
