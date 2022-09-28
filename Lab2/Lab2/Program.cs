﻿using System;
using System.Text.Json.Nodes;
using Lab2.Collections;
using Lab2.Entities;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Airport airport = new Airport();
            /*bool f = true;

            while (f)
            {
                Console.WriteLine("\n1. Show all tickets");
                Console.WriteLine("2. Show all passengers");
                Console.WriteLine("3. Show the information about customer's tickets");
                Console.WriteLine("4. Show the total price of passenger's tickets");
                Console.WriteLine("5. Add new passenger");
                Console.WriteLine("6. Enter new ticket");
                Console.WriteLine("7. Buy a ticket");
                Console.WriteLine("8. Exit\n");
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        {
                            airport.PrintTickets();
                            break;
                        }
                    case 2:
                        {
                            airport.PrintPassengers();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter the name: ");
                            airport.PrintInfo(Console.ReadLine());
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter the name: ");
                            airport.PrintTotalPrice(Console.ReadLine());
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter the name");
                            string name = Console.ReadLine();
                            airport.AddPassenger(name);
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Enter the price: ");
                            int price = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the tariff: ");
                            string tariff = Console.ReadLine();
                            airport.AddTicket(price, tariff);
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Enter the name");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter the tariff");
                            string type = Console.ReadLine();
                            airport.BuyTicket(name, type);
                            break;
                        }
                    case 8:
                        {
                            f = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Incorrect input. Try again.");
                            break;
                        }
                }
            }*/
            Journal journal = new Journal();

            airport.TariffAdded += journal.AddToHistory;
            airport.PassengerAdded += journal.AddToHistory;

            airport.TicketPurchase += (string message) => Console.WriteLine(message);

            airport.AddPassenger("alex");
            airport.AddPassenger("dima");
            airport.AddTicket(100, "israel");
            airport.AddTicket(200, "belarus");
            airport.BuyTicket("alex", "israel");
            airport.BuyTicket("dima", "belarus");
            journal.ShowHistory();
        }
    }
}