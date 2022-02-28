using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalServiceApp.FrontEnd;

namespace RentalServiceApp.BackEnd
{
    public class Car
    {
        public Car(int carId, string model, string segment, string fuel, decimal price)
        {
            CarId = carId;
            Model = model;
            Segment = segment;
            FuelType = fuel;
            PricePerDay = price;

        }
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal PricePerDay { get; set; }
        public string Segment { get; set; }
        public string FuelType { get; set; }

    }
}
