using System;
using System.Collections.Generic;

public class Vehicle
{
    public string Make { get; private set; }
    public string Model { get; private set; }
    public int Year { get; private set; }
    private int _speed; 

    public Vehicle(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
        _speed = 0;  
    }

    public int GetSpeed()
    {
        return _speed;
    }

    public void SetSpeed(int speed)
    {
        if (speed >= 0)
        {
            _speed = speed;
        }
        else
        {
            throw new ArgumentException("Speed cannot be negative.");
        }
    }

    public void Accelerate(int amount)
    {
        SetSpeed(GetSpeed() + amount);
    }

    public void Brake(int amount)
    {
        int newSpeed = GetSpeed() - amount;
        SetSpeed(Math.Max(0, newSpeed));  
    }

    public override string ToString()
    {
        return $"{Year} {Make} {Model} (Speed: {GetSpeed()} mph)";
    }
}

public class Car : Vehicle
{
    public int Doors { get; private set; }

    public Car(string make, string model, int year, int doors)
        : base(make, model, year)
    {
        Doors = doors;
    }

    public override string ToString()
    {
        return $"{base.ToString()} with {Doors} doors";
    }
}

public class Truck : Vehicle
{
    public int CargoCapacity { get; private set; }  

    public Truck(string make, string model, int year, int cargoCapacity)
        : base(make, model, year)
    {
        CargoCapacity = cargoCapacity;
    }

    public override string ToString()
    {
        return $"{base.ToString()} with {CargoCapacity} tons capacity";
    }
}

public class Garage
{
    private List<Vehicle> vehicles;

    public Garage()
    {
        vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        if (vehicle != null)
        {
            vehicles.Add(vehicle);
        }
        else
        {
            throw new ArgumentException("Invalid vehicle.");
        }
    }

    public int TotalVehicles()
    {
        return vehicles.Count;
    }

    public override string ToString()
    {
        string vehicleList = string.Join(", ", vehicles);
        return $"Garage with {TotalVehicles()} vehicles: {vehicleList}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Car car1 = new Car("Toyota", "Corolla", 2020, 5);
        Truck truck1 = new Truck("Ford", "F-150", 2019, 4);

        car1.Accelerate(30);
        truck1.Accelerate(40);
        car1.Brake(10);

        Console.WriteLine(car1);  
        Console.WriteLine(truck1);  

        Garage myGarage = new Garage();
        myGarage.AddVehicle(car1);
        myGarage.AddVehicle(truck1);

        Console.WriteLine(myGarage);  
    }
}

