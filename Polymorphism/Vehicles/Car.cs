﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AirConditionerConsumation = 0.9;
        public Car(double quantity, double consumption, double tankCapacity) 
            : base(quantity, consumption,tankCapacity)
        {
            AirConditioner = AirConditionerConsumation;
        }

        public override void Drive(double distance)
        {
            this.TurnOnAirConditioner();
            if (FuelQuantity< distance*FuelConsumption)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * FuelConsumption;
            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }

        public override void Refuel(double liters)
        {
            FuelValidator.Validator(liters);
            if (TankCapacity<FuelQuantity+liters)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            FuelQuantity += liters;
        }
    }
}
