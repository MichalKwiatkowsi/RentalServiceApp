using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalServiceApp.BackEnd;

namespace RentalServiceApp.FrontEnd
{
    public static class Screen
    {
        public static void ShowOptions()
        {

            Console.WriteLine("Witaj w Wyporzyczalni Samochodów!");
            Console.WriteLine("1 => LISTA KLIENTÓW I SAMOCHODÓW");
            Console.WriteLine("2 => WYPOŻYCZENIE SAMOCHODU");
            Console.WriteLine("3 => ZAKOŃCZ PROGRAM");
            Console.WriteLine("Wybierz 1,2 lub 3");
            ChooseOptions();
        }
        public static void ChooseOptions()
        {

            string option = Console.ReadLine();
            while (true)
            {
                int value;
                if (int.TryParse(option, out value))
                {
                    switch (value)
                    {
                        case 1:
                            Options.FirstOption();
                            break;
                        case 2:
                            Options.SecondOption();
                            break;
                        case 3:
                            Options.ThirdOption();
                            break;
                        default:
                            Console.WriteLine("Zły klawisz");
                            Console.Clear();
                            ShowOptions();
                            break;
                    }
                }

            }
        }
        public static void Rent()
        {
            Console.Clear();
            Console.WriteLine("Proszę podać Id klienta:");
            Client ChoosedClient = null;
            RentalServiceClients clients = new();
            RentalServiceCars cars = new();
            while (true)
            {
                string option = Console.ReadLine();
                int value;
                if (int.TryParse(option, out value))
                {
                    ChoosedClient = clients.GetClientById(value);
                    if (ChoosedClient != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Proszę podać prawidłowe Id klienta:");
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("Wybierz Segment Samochodu:");
            Console.WriteLine("1. Mini");
            Console.WriteLine("2. Kompakt");
            string Segment = "";
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
                string option1 = Console.ReadLine();
                int value;
                if (int.TryParse(option1, out value))
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
                            Console.WriteLine("Niepoprawna opcja.");
                            Console.Clear();
                            Choice.ShowSegmentOption(ChoosedClient);
                            break;

                    }
                }

            }
            Console.Clear();
            Console.WriteLine("Wybierz rodzaj paliwa");
            Console.WriteLine("1. Benzyna");
            Console.WriteLine("2. Elektryczny");
            Console.WriteLine("3. Diesel");
            Console.WriteLine("Podaj rodzaj paliwa: ");
            string FuelType = "";
            GoodOption = false;
            while (!GoodOption)
            {
                string option2 = Console.ReadLine();
                int value;
                if (int.TryParse(option2, out value))
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
                            Console.WriteLine("Niepoprawna ocpcja");
                            Choice.ShowFuelOptions();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Niepoprawna ocpcja");
                    Choice.ShowFuelOptions();
                }
            }
            Console.Clear();
            int RentDays = 1;
            Console.WriteLine("Podaj ilość dni wynajmu pojazdu: ");
            GoodOption = false;
            while (!GoodOption)
            {
                string option3 = Console.ReadLine();
                int value;
                if (int.TryParse(option3, out value))
                {
                    RentDays = value;
                    break;
                }
                else
                {
                    Console.WriteLine("Niepoprawna opcja");
                    Console.Clear();
                    Console.WriteLine("Podaj ilość dni wynajmu pojazdu: ");
                }
            }
            Car ChoosedCar = null;
            while (true)
            {
                ChoosedCar = cars.GetCarBySegmentFuel(Segment, FuelType);
                if (ChoosedCar == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                    Console.WriteLine(" Prosze wybrać poprawną opcję: ");
                    Choice.ShowSegmentChoice(ChoosedClient, ref Segment);
                    Choice.ShowFuelChoice(ref FuelType);

                }
                else
                {
                    break;
                }
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("UMOWA WYNAJMU POJAZDU");
            Console.WriteLine($"DATA ZAWARCIA: {DateTime.Now}");
            Console.WriteLine($"WYNAJMUJĄCY/A: {ChoosedClient.FullName}");
            Console.WriteLine($"RODZAJ POJAZDU: {ChoosedCar.Model}");
            Console.WriteLine($"SEGMENT: {Segment}");
            Console.WriteLine($"RODZAJ PALIWA: {FuelType}");
            int RentFree = 1;
            if (RentDays > 30)
            {
                RentFree = RentDays + 3;
            }
            else if (RentDays > 7)
            {
                RentFree = RentDays + 1;
            }
            DateTime zwrot = DateTime.Now.AddDays(RentFree);
            Console.WriteLine($"DATA ZWROTU POJAZDU: {zwrot.ToString("dd/MM/yyyy")}");
            Console.WriteLine();
            decimal Price = ChoosedCar.PricePerDay * RentDays;
            decimal PlusPrice = 1.2m;
            if (Experience > 4)
                Price = Decimal.Multiply(Price, PlusPrice);
            Console.WriteLine($"OPŁATA: {Price} PLN");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            ShowOptions();

        }

        public static void PokazKlientow()
        {
            Console.Clear();
            Console.WriteLine("Lista Klientów:");
            Console.WriteLine("");
            Console.WriteLine("Id | Imię i nazwisko | Data wydania prawa jazdy");
            Console.WriteLine("1 | Jan Nowak | 04.03.2021");
            Console.WriteLine("2 | Agnieszka Kowalska | 15.01.1999");
            Console.WriteLine("3 | Robert Lewandowski | 18.12.2010");
            Console.WriteLine("4 | Zofia Plucińska | 29.04.2020");
            Console.WriteLine("5 | Grzegorz Braun | 12.07.2015");
            Console.WriteLine("");
            Console.WriteLine("Lista Samochodów:");
            Console.WriteLine("");
            Console.WriteLine("Id | Model | Segment | Rodzaj paliwa | Cena za dobę");
            Console.WriteLine("1 | Škoda Citigo | mini | benzyna | 70 PLN");
            Console.WriteLine("2 | Toyota Aygo | mini | benzyna | 90 PLN");
            Console.WriteLine("3 | Fiat 500 | mini | elektryczny | 110 PLN");
            Console.WriteLine("4 | Ford Focus | kompakt | diesel | 160 PLN");
            Console.WriteLine("5 | Kia Ceed | kompakt | benzyna | 150 PLN");
            Console.WriteLine("6 | Volkswagen Golf | kompakt | benzyna | 160 PLN");
            Console.WriteLine("7 | Hyundai Kona Electric | kompakt | elektryczny | 180 PLN");
            Console.WriteLine("8 | Audi A6 Allroad | premium | diesel | 290 PLN");
            Console.WriteLine("9 | Mercedes E270 AMG | premium | benzyna | 320 PLN");
            Console.WriteLine("10 | Tesla Model S | premium | elektryczny | 350 PLN");
            Console.WriteLine("");
        }
    }
}
