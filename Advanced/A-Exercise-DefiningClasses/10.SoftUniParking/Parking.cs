﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking;

public class Parking
{
    private Dictionary<string, Car> cars;
    private int capacity;

    public Parking(int capacity)
    {
        this.capacity = capacity;
        cars = new();
    }

    public int Count
    {
        get { return cars.Count; }
    }

    public string AddCar(Car car)
    {
        if (cars.ContainsKey(car.RegistrationNumber))
        {
            return "Car with that registration number, already exists!";
        }

        if (cars.Count >= capacity)
        {
            return "Parking is full!";
        }

        cars.Add(car.RegistrationNumber, car);

        return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
    }

    public string RemoveCar(string registrationNumber)
    {
        if (cars.ContainsKey(registrationNumber)) {
            cars.Remove(registrationNumber);

            return $"Successfully removed {registrationNumber}";
        }

        return "Car with that registration number, doesn't exist!";
    }

    public Car GetCar(string registrationNumber)
    {
        if (cars.ContainsKey(registrationNumber))
        {
            return cars[registrationNumber];
        }

        return null;
    }

    public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
    {
        registrationNumbers.ForEach(n => RemoveCar(n));
    }
}
