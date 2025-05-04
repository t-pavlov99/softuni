using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftUniParking;

public class Parking
{
    private List<Car> cars;
    private int capacity;

    public int Count { get { return cars.Count; } }
    public Parking(int capacity)
    {
        cars = new List<Car>();
        this.capacity = capacity;
    }

    public string AddCar(Car car)
    {
        if (cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
        {
            return "Car with that registration number, already exists!";
        }

        if (cars.Count == capacity)
        {
            return "Parking is full!";
        }

        cars.Add(car);
        return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
    }

    public string RemoveCar(string registrationNumber)
    {
        int index = cars.FindIndex(x => x.RegistrationNumber == registrationNumber);
        if (index != -1)
        {
            cars.RemoveAt(index);
            return $"Successfully removed {registrationNumber}";
        }
        return $"Car with that registration number, doesn't exist!";
    }

    public Car GetCar(string registrationNumber)
    {
        return cars.Find(x => x.RegistrationNumber == registrationNumber);
    }

    public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
    {
        foreach (string registrationNumber in RegistrationNumbers)
        {
            RemoveCar(registrationNumber);
        }
    }
}

