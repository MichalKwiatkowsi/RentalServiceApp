using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalServiceApp.FrontEnd;

namespace RentalServiceApp.BackEnd
{
    internal class Choice
    {   
        public static void ShowSegmentOption(Client ChoosedClient)
        {
            Console.Clear();
            Console.WriteLine("Wybierz Segment Samochodu:");
            Console.WriteLine("1. Mini");
            Console.WriteLine("2. Kompakt");
            var someDate = DateTime.Now;
            var someDate1 = ChoosedClient.DrivingLicenceIssueDate.Date;
            int Experience = someDate.Year - someDate1.Year;
            if (Experience >= 4)
            {
                Console.WriteLine("3. Premium");
            }
            Console.WriteLine("Podaj segment samochodu: ");
        }

        public static void ShowFuelOptions()
        {

            Console.Clear();
            Console.WriteLine("Wybierz rodzaj paliwa");
            Console.WriteLine("1. Benzyna");
            Console.WriteLine("2. Elektryczny");
            Console.WriteLine("3. Diesel");
            Console.WriteLine("Podaj rodzaj paliwa: ");
        }

        public static void ShowSegmentChoice(Client ChoosedClient, ref string Segment)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Wybierz Segment Samochodu:");
            Console.WriteLine("1. Mini");
            Console.WriteLine("2. Kompakt");
            var someDate = DateTime.Now;
            var someDate1 = ChoosedClient.DrivingLicenceIssueDate.Date;
            int Experience = someDate.Year - someDate1.Year;
            if (Experience >= 4)
            {
                Console.WriteLine("3. Premium");
            }

            Console.WriteLine("Podaj segment samochodu: ");
            bool GoodOption = false;
            while (!GoodOption)
            {
                string option = Console.ReadLine();
                int value;
                if (int.TryParse(option, out value))
                {
                    switch (value)
                    {
                        case 1:
                            Segment = "mini";
                            GoodOption = true;
                            break;
                        case 2:
                            Segment = "kompakt";
                            GoodOption = true;
                            break;
                        case 3:
                            {
                                if (Experience >= 4)
                                {
                                    Segment = "premium";
                                    GoodOption = true;
                                    break;
                                }
                                goto default;
                            }
                        default:
                            Console.WriteLine("Niepoprawna opcja");
                            ShowSegmentOption(ChoosedClient);
                            return;

                    }
                }
            }
        }
        public static void ShowFuelChoice(ref string FuelType)
        {
            Console.Clear();
            Console.WriteLine("Wybierz rodzaj paliwa");
            Console.WriteLine("1. Benzyna");
            Console.WriteLine("2. Elektryczny");
            Console.WriteLine("3. Diesel");
            Console.WriteLine("Podaj rodzaj paliwa: ");
            bool GoodOption = false;
            while (!GoodOption)
            {
                string option = Console.ReadLine();
                int value;
                if (int.TryParse(option, out value))
                {
                    switch (value)
                    {
                        case 1:
                            FuelType = "benzyna";
                            GoodOption = true;
                            break;
                        case 2:
                            FuelType = "elektryczny";
                            GoodOption = true;
                            break;
                        case 3:
                            FuelType = "diesel";
                            GoodOption = true;
                            break;
                        default:
                            Console.WriteLine("Opcja o danym numerze nie istnieje.");
                            ShowFuelOptions();
                            break;
                    }
                }
            }
            Console.Clear();
            int dniWynajmu = 1;
            Console.WriteLine("Podaj ilość dni wynajmu pojazdu: ");
            GoodOption = false;
            while (!GoodOption)
            {
                string option = Console.ReadLine();
                int value;
                if (int.TryParse(option, out value))
                {
                    dniWynajmu = value;
                    break;
                }
                else
                {
                    Console.WriteLine("Niepoprawna opcja");
                    Console.Clear();
                    Console.WriteLine("Podaj ilość dni wynajmu pojazdu: ");
                }
            }
        }
    }
}
