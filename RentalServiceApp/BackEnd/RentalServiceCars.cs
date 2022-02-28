using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalServiceApp.FrontEnd;

namespace RentalServiceApp.BackEnd
{
    internal class RentalServiceCars
    {
        public RentalServiceCars()
        {
            CreateCars();
        }
        public List<Car> Cars { get; set; } = new List<Car>();
        private void CreateCars()
        {
            Cars.Add(new Car(1, "Škoda Citigo", "mini", "benzyna", 70m));
            Cars.Add(new Car(2, "Toyota Aygo", "mini", "benzyna", 90m));
            Cars.Add(new Car(3, "Fiat 500", "mini", "elektryczny", 110m));
            Cars.Add(new Car(4, "Ford Focus", "kompakt", "diesel", 160m));
            Cars.Add(new Car(5, "Kia Ceed", "kompakt", "benzyna", 150m));
            Cars.Add(new Car(6, "Volkswagen Golf", "kompakt", "benzyna", 160m));
            Cars.Add(new Car(7, "Hyundai Kona Electric", "kompakt", "elektryczny", 180m));
            Cars.Add(new Car(8, "Audi A6 Allroad", "premium", "diesel ", 290m));
            Cars.Add(new Car(9, "Mercedes E270 AMG", "premium", "benzyna", 320m));
            Cars.Add(new Car(10, "Tesla Model S", "premium", "elektryczny", 350m));
        }
        public Car GetCarBySegmentFuel(string Segment, string Fuel)
        {
            foreach (var car in this.Cars)
            {
                if (Segment == car.Segment)
                {
                    if (Fuel == car.FuelType)
                        return car;
                }
            }
            return null;
        }
    }
}
