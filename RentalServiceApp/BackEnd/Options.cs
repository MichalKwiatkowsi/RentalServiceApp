using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalServiceApp.FrontEnd;

namespace RentalServiceApp.BackEnd
{
    internal class Options
    {
        public static void FirstOption()
        {
            Console.Clear();
            Screen.PokazKlientow();
            Screen.ShowOptions();
        }
        public static void SecondOption()
        {
            Screen.Rent();
        }
        public static void ThirdOption()
        {
            Environment.Exit(0);
        }
    }
}
