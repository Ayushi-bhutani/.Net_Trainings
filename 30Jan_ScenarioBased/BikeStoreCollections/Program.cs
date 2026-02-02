using System;
using System.Collections.Generic;

public class Program
{
    
    public static SortedDictionary<int, Bike> bikeDetails = new SortedDictionary<int, Bike>();

    public static void Main(string[] args)
    {
        BikeUtility utility = new BikeUtility();
        int choice;

        do
        {
            Console.WriteLine("1. Add Bike Details");
            Console.WriteLine("2. Group Bikes By Brand");
            Console.WriteLine("3. Exit");
            Console.WriteLine();
            Console.WriteLine("Enter your choice");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the model");
                    string model = Console.ReadLine();

                    Console.WriteLine("Enter the brand");
                    string brand = Console.ReadLine();

                    Console.WriteLine("Enter the price per day");
                    int price = int.Parse(Console.ReadLine());

                    utility.AddBikeDetails(model, brand, price);
                    Console.WriteLine("Bike details added successfully");
                    Console.WriteLine();
                    break;

                case 2:
                    SortedDictionary<string, List<Bike>> groupedBikes = utility.GroupBikesByBrand();

                    foreach (var item in groupedBikes)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Bike bike in item.Value)
                        {
                            Console.WriteLine(bike.Model);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("Bikes are grouped");
                    break;

                case 3:
                    break;
            }

        } while (choice != 3);
    }
}
