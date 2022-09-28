using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Collections;
using Lab2.Interfaces;

namespace Lab2
{
    public class Airport
    {
        public delegate void MessageHandler(string message);
        public event MessageHandler TariffAdded;
        public event MessageHandler PassengerAdded;
        public event MessageHandler TicketPurchase;
        private ICustomCollection<Passenger> passengers;
        private ICustomCollection<Ticket> tickets;

        public Airport() 
        {
            passengers = new MyCustomCollection<Passenger>();
            tickets = new MyCustomCollection<Ticket>();
        }
        public void AddPassenger(string name)
        {
            passengers.Add(new Passenger(name));
            PassengerAdded?.Invoke($"Passenger {name} was added");
        }
        public void AddTicket(Ticket ticket)
        {
            tickets.Add(ticket);
        }
        public void AddTicket(int Price, string Tariff)
        {
            tickets.Add(new Ticket(Price, Tariff));
            TariffAdded?.Invoke($"Tariff {Tariff} was added");
        }
        public void BuyTicket(string passenger_name, string tariff, int price)
        {
            foreach (Passenger passenger in passengers)
            {
                if (passenger.Name == passenger_name)
                {
                    foreach (Ticket ticket in tickets)
                    {
                        if (ticket.Tariff == tariff)
                        {
                            if (ticket.Price == price)
                            {
                                passenger.Buy(ticket);
                                return;
                            }
                        }
                    }
                    AddTicket(price, tariff);
                    passenger.Buy(tickets[tickets.Count - 1]);
                    TicketPurchase?.Invoke($"Passenger {passenger_name} bought ticket to {tariff}");
                    return;
                }
            }
            AddPassenger(passenger_name);
            BuyTicket(passenger_name, tariff, price);
            return;
        }
        public void PrintInfo(string passenger_name)
        {
            foreach (Passenger passenger in passengers)
            {
                if (passenger.Name == passenger_name)
                {
                    if (passenger.Tickets.Count == 0)
                    {
                        Console.WriteLine("\n################################\n");
                        Console.WriteLine("{0} has no tickets", passenger.Name);
                        Console.WriteLine("\n################################\n");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\n################################\n");
                        Console.WriteLine("{0} has {1} tickets:", passenger.Name, passenger.Tickets.Count);
                        foreach (Ticket ticket in tickets)
                        {
                            Console.WriteLine("{0} - {1}", ticket.Tariff, ticket.Price);
                        }
                        Console.WriteLine("\n################################\n");
                        return;
                    }
                }
            }
            Console.WriteLine("Passenger not found");
            return;
        }
        public void PrintTotalPrice(string passenger_name)
        {
            foreach (Passenger passenger in passengers)
            {
                if (passenger.Name == passenger_name)
                {
                    if (passenger.Tickets.Count == 0)
                    {
                        Console.WriteLine("\n################################\n");
                        Console.WriteLine("{0} has no tickets", passenger.Name);
                        Console.WriteLine("\n################################\n");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\n################################\n");
                        Console.WriteLine("Total price: {0}", passenger.GetTotalPrice());
                        Console.WriteLine("\n################################\n");
                        return;
                    }
                }
            }
            Console.WriteLine("Passenger not found");
            return;
        }
        public void PrintTickets()
        {
            Console.WriteLine("\n################################\n");
            foreach (Ticket ticket in tickets)
            {
                Console.WriteLine("{0} - {1}", ticket.Tariff, ticket.Price);
            }
            Console.WriteLine("\n################################\n");
        }
        public void PrintPassengers()
        {
            Console.WriteLine("\n################################\n");
            foreach (Passenger passenger in passengers)
            {
                Console.WriteLine("{0}", passenger.Name);
            }
            Console.WriteLine("\n################################\n");
        }
        public void BuyTicket(string passenger_name, string tariff)
        {
            foreach (Passenger passenger in passengers)
            {
                if (passenger.Name == passenger_name)
                {
                    foreach (Ticket ticket in tickets)
                    {
                        if (ticket.Tariff == tariff)
                        {
                            passenger.Buy(ticket);
                            TicketPurchase?.Invoke($"Passenger {passenger_name} bought ticket to {tariff}");
                            return;
                        }
                    }
                    Console.WriteLine("Ticket not found");
                    Console.WriteLine("Enter the price: ");
                    AddTicket(Convert.ToInt32(Console.ReadLine()), tariff);
                    passenger.Buy(tickets[tickets.Count - 1]);
                    return;
                }
            }
            AddPassenger(passenger_name);
            BuyTicket(passenger_name, tariff);
            return;
        }

    }
}
