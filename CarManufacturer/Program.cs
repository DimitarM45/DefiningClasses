using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<Tire[]> tires = new List<Tire[]>();

            while (input[0] != "No")
            {
                Tire[] carTires = new Tire[4]
                {
                    new Tire(int.Parse(input[0]), double.Parse(input[1])),
                    new Tire(int.Parse(input[2]), double.Parse(input[3])),
                    new Tire(int.Parse(input[4]), double.Parse(input[5])),
                    new Tire(int.Parse(input[6]), double.Parse(input[7]))
                };

                tires.Add(carTires);

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<Engine> engines = new List<Engine>();

            while (input[0] != "Engines")
            {
                engines.Add(new Engine(int.Parse(input[0]), double.Parse(input[1])));

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<Car> cars = new List<Car>();

            while (input[0] != "Show")
            {
                string make = input[0];
                string model = input[1];

                int year = int.Parse(input[2]);

                double fuelQuantity = double.Parse(input[3]);
                double fuelConsumption = double.Parse(input[4]);

                int engineIndex = int.Parse(input[5]);
                int tiresIndex = int.Parse(input[6]);

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]));

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            List<Car> specialCars = new List<Car>();

            foreach (Car car in cars)
            {
                if (car.Year >= 2017 && car.Engine.HorsePower > 330)
                {
                    double tirePressureSum = 0;

                    foreach (Tire tire in car.Tires)
                        tirePressureSum += tire.Pressure;

                    if (tirePressureSum > 9 && tirePressureSum < 10)
                        specialCars.Add(car);
                }
            }

            foreach (Car specialCar in specialCars)
            {
                specialCar.Drive(20);

                Console.WriteLine($"Make: {specialCar.Make}");
                Console.WriteLine($"Model: {specialCar.Model}");
                Console.WriteLine($"Year: {specialCar.Year}");
                Console.WriteLine($"HorsePowers: {specialCar.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {specialCar.FuelQuantity}");
            }
        }
    }
}
