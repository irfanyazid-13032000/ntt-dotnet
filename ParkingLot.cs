using System;
using System.Collections.Generic;
using System.Linq;

public class ParkingLot
{
    private int capacity;
    private Dictionary<int, Vehicle> parkingSlots;

    public ParkingLot(int capacity)
    {
        this.capacity = capacity;
        parkingSlots = new Dictionary<int, Vehicle>();
    }

    public void ParkVehicle(string registrationNumber, string color, string vehicleType)
    {
        if (IsFull())
        {
            Console.WriteLine("Sorry, parking lot is full");
            return;
        }

        int slotNumber = GetNextAvailableSlot();
        parkingSlots[slotNumber] = new Vehicle(registrationNumber, vehicleType, color);
        Console.WriteLine($"Allocated slot number: {slotNumber}");
    }

    public void Leave(int slotNumber)
    {
        if (!parkingSlots.ContainsKey(slotNumber))
        {
            Console.WriteLine($"Slot number {slotNumber} is already empty");
            return;
        }

        parkingSlots.Remove(slotNumber);
        Console.WriteLine($"Slot number {slotNumber} is free");
    }

    public void PrintStatus()
    {
        Console.WriteLine("Slot\tType\tRegistration No\tColour");
        foreach (var slot in parkingSlots.OrderBy(s => s.Key))
        {
            Console.WriteLine($"{slot.Key}\t{slot.Value.VehicleType,-10}\t{slot.Value.RegistrationNumber,-16}\t{slot.Value.Color,-10}");
        }
    }

    public int CountVehiclesByType(string vehicleType)
    {
        return parkingSlots.Count(slot => slot.Value.VehicleType.Equals(vehicleType, StringComparison.OrdinalIgnoreCase));
    }

    private bool IsOddPlate(string registrationNumber)
    {
        // Ambil karakter tengah dari nomor registrasi
        int middleIndex = registrationNumber.Length / 2;
        char middleCharacter = registrationNumber[middleIndex];

        // Periksa apakah karakter tengah adalah angka
        if (char.IsDigit(middleCharacter))
        {
            // Parse karakter tengah sebagai integer
            int middleDigit = int.Parse(middleCharacter.ToString());

            // Periksa apakah digit yang di-parse adalah angka ganjil
            return middleDigit % 2 != 0;
        }

        // Jika karakter tengah bukan angka, handle sesuai kebutuhan
        return false;
    }

    public List<string> GetRegistrationNumbersForOddPlate()
    {
        List<string> oddPlateRegistrationNumbers = parkingSlots.Values
            .Where(vehicle =>
            {
                bool isOdd = IsOddPlate(vehicle.RegistrationNumber);
                return isOdd;
            })
            .Select(vehicle => vehicle.RegistrationNumber)
            .ToList();

        return oddPlateRegistrationNumbers.Distinct().ToList();
    }

    public List<string> GetRegistrationNumbersForEvenPlate()
    {
        List<string> evenPlateRegistrationNumbers = parkingSlots.Values
            .Where(vehicle =>
            {
                bool isOdd = IsOddPlate(vehicle.RegistrationNumber);
                bool isEven = !isOdd;
                return isEven;
            })
            .Select(vehicle => vehicle.RegistrationNumber)
            .ToList();

        return evenPlateRegistrationNumbers.Distinct().ToList();
    }

    public List<string> GetRegistrationNumbersByColor(string color)
    {
        return parkingSlots.Values
            .Where(vehicle => vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
            .Select(vehicle => vehicle.RegistrationNumber)
            .ToList();
    }

    public List<int> GetSlotNumbersByColor(string color)
    {
        return parkingSlots.Where(slot => slot.Value.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
            .Select(slot => slot.Key)
            .ToList();
    }

    public int GetSlotNumberByRegistrationNumber(string registrationNumber)
    {
        var vehicle = parkingSlots.FirstOrDefault(slot => slot.Value.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase)).Value;
        return vehicle != null ? parkingSlots.First(slot => slot.Value.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase)).Key : -1;
    }

    public List<string> GetRegistrationNumbersByVehicleType(string vehicleType)
    {
        return parkingSlots.Values
            .Where(vehicle => vehicle.VehicleType.Equals(vehicleType, StringComparison.OrdinalIgnoreCase))
            .Select(vehicle => vehicle.RegistrationNumber)
            .ToList();
    }

    private int GetNextAvailableSlot()
    {
        for (int i = 1; i <= capacity; i++)
        {
            if (!parkingSlots.ContainsKey(i))
            {
                return i;
            }
        }
        return -1;
    }

    private bool IsFull()
    {
        return parkingSlots.Count >= capacity;
    }
}

public class Vehicle
{
    public string RegistrationNumber { get; }
    public string Color { get; }
    public string VehicleType { get; }

    public Vehicle(string registrationNumber, string vehicleType, string color)
    {
        RegistrationNumber = registrationNumber;
        Color = color;
        VehicleType = vehicleType;
    }
}
