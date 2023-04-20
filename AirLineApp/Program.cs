
using System;
using System.Collections.Generic;

// Абстрактный класс Самолет
abstract class Aircraft
{
   
    private string model;
    private int range;
    private int capacity;
    private int payload;
    private double fuelConsumption;

   
    public Aircraft(string model, int range, int capacity, int payload, double fuelConsumption)
    {
        this.model = model;
        this.range = range;
        this.capacity = capacity;
        this.payload = payload;
        this.fuelConsumption = fuelConsumption;
    }

    
    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    
    public int Range
    {
        get { return range; }
        set { range = value; }
    }

    
    public int Capacity
    {
        get { return capacity; }
        set { capacity = value; }
    }

    
    public int Payload
    {
        get { return payload; }
        set { payload = value; }
    }

    
    public double FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }

    // Абстрактный метод для расчета нагрузки
    public abstract int CalculateUsefulLoad();

    
    public override string ToString()
    {
        return model + " - Range: " + range + ", Capacity: " + capacity + ", Payload: " + payload + ", Fuel Consumption: " + fuelConsumption;
    }
}


class PassengerAircraft : Aircraft
{
    
    private string aircraftClass;

    
    public PassengerAircraft(string model, int range, int capacity, int payload, double fuelConsumption, string aircraftClass) : base(model, range, capacity, payload, fuelConsumption)
    {
        this.aircraftClass = aircraftClass;
    }

    
    public string AircraftClass
    {
        get { return aircraftClass; }
        set { aircraftClass = value; }
    }

    // Реализация абстрактного метода расчета полезной нагрузки
    public override int CalculateUsefulLoad()
    {
        return Capacity + Payload;
    }

    
    public override string ToString()
    {
        return base.ToString() + ", Class: " + aircraftClass;
    }
}


class CargoAircraft : Aircraft
{
    
    private string cargoType;

    
    public CargoAircraft(string model, int range, int capacity, int payload, double fuelConsumption, string cargoType) : base(model, range, capacity, payload, fuelConsumption)
    {
        this.cargoType = cargoType;
    }

    
    public string CargoType
    {
        get { return cargoType; }
        set { cargoType = value; }
    }

    // Реализация абстрактного метода расчета полезной нагрузки
    public override int CalculateUsefulLoad()
    {
        return Payload;
    }

 
    public override string ToString()
    {
        return base.ToString() + ", Cargo Type: " + cargoType;
    }
}

class Airline {
    public List<Aircraft> aircrafts;
    
    public Airline()
    {
        aircrafts = new List<Aircraft>();
    }

    
    public void AddAircraft(Aircraft aircraft)
    {
        aircrafts.Add(aircraft);
    }

    
    public void RemoveAircraft(Aircraft aircraft)
    {
        aircrafts.Remove(aircraft);
    }

    
    public int GetTotalCapacity()
    {
        int totalCapacity = 0;

        foreach (Aircraft aircraft in aircrafts)
        {
            totalCapacity += aircraft.Capacity;
        }

        return totalCapacity;
    }

   
    public int GetTotalPayload()
    {
        int totalPayload = 0;

        foreach (Aircraft aircraft in aircrafts)
        {
            totalPayload += aircraft.Payload;
        }

        return totalPayload;
    }

    
    public void SortAircraftByRange()
    {
        aircrafts.Sort((a1, a2) => a1.Range.CompareTo(a2.Range));
    }

    public List<Aircraft> FindAircraftByFuelConsumption(double minFuelConsumption, double maxFuelConsumption)
    {
        List<Aircraft> result = new List<Aircraft>();

        foreach (Aircraft aircraft in aircrafts)
        {
            if (aircraft.FuelConsumption >= minFuelConsumption && aircraft.FuelConsumption <= maxFuelConsumption)
            {
                result.Add(aircraft);
            }
        }

        return result;
    }
}



class Program
{
    static void Main(string[] args)
    {
        
        PassengerAircraft boeing = new PassengerAircraft("Boeing 747", 660, 14300, 238, 10.1, "comfort");
        PassengerAircraft airbus = new PassengerAircraft("Airbus A380", 853, 15200, 262, 12.5, "comfort");

        CargoAircraft antonov = new CargoAircraft("Antonov An-225", 250000, 15400, 100000, 22.5, "Heavy");
        CargoAircraft boeingCargo = new CargoAircraft("Boeing 747-400F", 230000, 8100, 113000, 19.1, "Standard");

        
        Airline airline = new Airline();

        
        airline.AddAircraft(boeing);
        airline.AddAircraft(airbus);
        airline.AddAircraft(antonov);
        airline.AddAircraft(boeingCargo);

        // Выводим информацию о всех самолетах компании
        Console.WriteLine("All aircraft in the airline:");
        foreach (Aircraft aircraft in airline.aircrafts)
        {
            Console.WriteLine(aircraft);
        }
        Console.WriteLine();

        // Выводим общую вместимость и грузоподъемность компании
        Console.WriteLine("Total capacity of the airline: " + airline.GetTotalCapacity());
        Console.WriteLine("Total payload of the airline: " + airline.GetTotalPayload());
        Console.WriteLine();

        // Сортируем самолеты компании по дальности полета
        airline.SortAircraftByRange();
        Console.WriteLine("Aircraft sorted by range:");
        foreach (Aircraft aircraft in airline.aircrafts)
        {
            Console.WriteLine(aircraft);
        }
        Console.WriteLine();

        // Ищем самолеты в компании, соответствующие заданному диапазону параметров потребления горючего
        double minFuelConsumption = 10.0;
        double maxFuelConsumption = 20.0;
        List<Aircraft> aircraftsByFuelConsumption = airline.FindAircraftByFuelConsumption(minFuelConsumption, maxFuelConsumption);

        Console.WriteLine("Aircraft with fuel consumption between " + minFuelConsumption + " and " + maxFuelConsumption + ":");
        foreach (Aircraft aircraft in aircraftsByFuelConsumption)
        {
            Console.WriteLine(aircraft);
        }

        Console.ReadKey();
    }
}



