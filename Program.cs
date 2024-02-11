using System;

class Program
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
                        int count = parkingLot.CountVehiclesByType(parts[1]);
                        Console.WriteLine(count);
                    }
                    break;

                case "registration_numbers_for_vehicles_with_odd_plate":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first.");
                    }
                    else
                    {
                        var oddPlateNumbers = parkingLot.GetRegistrationNumbersForOddPlate();
                        Console.WriteLine(string.Join(", ", oddPlateNumbers));
                    }
                    break;

                case "registration_numbers_for_vehicles_with_even_plate":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first.");
                    }
                    else
                    {
                        var evenPlateNumbers = parkingLot.GetRegistrationNumbersForEvenPlate();
                        Console.WriteLine(string.Join(", ", evenPlateNumbers));
                    }
                    break;


            

                case "registration_numbers_for_vehicles_with_colour":
                      if (parkingLot == null)
                      {
                          Console.WriteLine("Please create a parking lot first.");
                      }
                      else
                      {
                          var color = parts[1];
                          var registrationNumbers = parkingLot.GetRegistrationNumbersByColor(color);
                          Console.WriteLine(string.Join(", ", registrationNumbers));
                      }
                      break;


                case "slot_numbers_for_vehicles_with_colour":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create a parking lot first.");
                        }
                        else
                        {
                            var color = parts[1];
                            var slotNumbers = parkingLot.GetSlotNumbersByColor(color);
                            Console.WriteLine(string.Join(", ", slotNumbers));
                        }
                        break;


                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }
}
