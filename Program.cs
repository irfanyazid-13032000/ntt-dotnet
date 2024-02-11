﻿
public class Program
{
    static void Main(string[] args)
    {
        ParkingLot parkingLot = null;

        while (true)
        {
            string command = Console.ReadLine();
            string[] parts = command.Split(' ');

            switch (parts[0])
            {
                case "create_parking_lot":
                    int capacity = int.Parse(parts[1]);
                    parkingLot = new ParkingLot(capacity);
                    Console.WriteLine($"Created a parking lot with {capacity} slots");
                    break;

                case "park":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first.");
                    }
                    else
                    {
                        parkingLot.ParkVehicle(parts[1], parts[3], parts[2]);
                    }
                    break;

                case "leave":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first.");
                    }
                    else
                    {
                        parkingLot.Leave(int.Parse(parts[1]));
                    }
                    break;

                case "status":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first.");
                    }
                    else
                    {
                        parkingLot.PrintStatus();
                    }
                    break;

               case "type_of_vehicles":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first.");
                    }
                    else
                    {
                        string typeOrColor = parts[1];

                        int count = parkingLot.CountVehiclesByType(typeOrColor);

                        Console.WriteLine(count);
                    }
                    break;


                case "registration_numbers_for_vehicles_with_ood_plate":
                      if (parkingLot == null)
                      {
                          Console.WriteLine("Please create a parking lot first.");
                      }
                      else
                      {
                          List<string> oddPlateRegistrationNumbers = parkingLot.GetRegistrationNumbersForOddPlate();
                          string result = string.Join(", ", oddPlateRegistrationNumbers);
                          Console.WriteLine(result);
                      }
                      break;



                // ... other cases for different commands ...

                case "exit":
                    Console.WriteLine("Exiting the program.");
                    return;

                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }
}