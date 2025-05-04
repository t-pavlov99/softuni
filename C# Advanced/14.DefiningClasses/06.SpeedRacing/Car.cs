using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses;

public class Car
{
    public string Model;
    public double FuelAmount;
    public double FuelConsumptionPerKilometer;
    public double TravelledDistance;

    public Car(string model, double fuelAmount, double fuelConsumption, double travelledDistance)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumptionPerKilometer = fuelConsumption;
        TravelledDistance = travelledDistance;

    }

    public Car(string model, double fuelAmount, double fuelConsumption)
        : this(model, fuelAmount, fuelConsumption, 0) { }

    public void Drive(double distance)
    {
        double fuelRequired = distance * FuelConsumptionPerKilometer;
        if (FuelAmount >= fuelRequired)
        {
            FuelAmount -= fuelRequired;
            TravelledDistance += distance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }

    public override string ToString()
    {
        return $"{Model} {FuelAmount:f2} {TravelledDistance}";
    }
}