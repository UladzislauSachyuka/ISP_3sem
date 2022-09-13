using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Sachivko_Lab1.Collections;

namespace _153502_Sachivko_Lab1
{
    public class Airport
    {
        private MyCustomCollection<Passenger> passengers;
        private MyCustomCollection<Ticket> tickets;

        public Airport() 
        {
            passengers = new MyCustomCollection<Passenger>();
            tickets = new MyCustomCollection<Ticket>();
        }
        public void AddPassenger(string name)
        {
            passengers.Add(new Passenger(name));
        }
        public void AddTicket(Ticket ticket)
        {
            tickets.Add(ticket);
        }
        public void AddTicket(int Price, Ticket.Tariff Tariff)
        {
            tickets.Add(new Ticket(Price, Tariff));
        }
        public void BuyTicket(string passenger_name, Ticket.Tariff tariff, int price)
        {
            for (int i = 0; i < passengers.Count; ++i)
            {
                if (passengers[i].Name == passenger_name)
                {
                    for (int j = 0; j < tickets.Count; ++j)
                    {
                        if (tickets[j].Type == tariff)
                        {
                            if (tickets[j].Price == price)
                            {
                                passengers[i].Buy(tickets[j]);
                                return;
                            }
                        }
                    }
                    AddTicket(price, tariff);
                    passengers[i].Buy(tickets[tickets.Count - 1]);
                    return;
                }
            }
            AddPassenger(passenger_name);
            BuyTicket(passenger_name, tariff, price);
            return;
        }
        public void PrintInfo(string passenger_name)
        {
            for (int i = 0; i < passengers.Count; ++i)
            {
                if (passengers[i].Name == passenger_name)
                {
                    if (passengers[i].Tickets.Count == 0)
                    {
                        Console.WriteLine("\n################################\n");
                        Console.WriteLine("{0} has no tickets", passengers[i].Name);
                        Console.WriteLine("\n################################\n");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\n################################\n");
                        Console.WriteLine("{0} has {1} tickets:", passengers[i].Name, passengers[i].Tickets.Count);
                        for (int j = 0; j < tickets.Count; ++j)
                        {
                            Console.WriteLine("{0} - {1}", tickets[j].Type, tickets[j].Price);
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
            for (int i = 0; i < passengers.Count; ++i)
            {
                if (passengers[i].Name == passenger_name)
                {
                    if (passengers[i].Tickets.Count == 0)
                    {
                        Console.WriteLine("\n################################\n");
                        Console.WriteLine("{0} has no tickets", passengers[i].Name);
                        Console.WriteLine("\n################################\n");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\n################################\n");
                        Console.WriteLine("Total price: {0}", passengers[i].GetTotalPrice());
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
            for (int i = 0; i < tickets.Count; ++i)
            {
                Console.WriteLine("{0} - {1}", tickets[i].Type, tickets[i].Price);
            }
            Console.WriteLine("\n################################\n");
        }
        public void PrintPassengers()
        {
            Console.WriteLine("\n################################\n");
            for (int i = 0; i < passengers.Count; ++i)
            {
                Console.WriteLine("{0}", passengers[i].Name);
            }
            Console.WriteLine("\n################################\n");
        }
        public void BuyTicket(string passenger_name, string type)
        {
            Ticket.Tariff tariff = (Ticket.Tariff) Enum.Parse(typeof(Ticket.Tariff), type);
            for (int i = 0; i < passengers.Count; ++i)
            {
                if (passengers[i].Name == passenger_name)
                {
                    for (int j = 0; j < tickets.Count; ++j)
                    {
                        if (tickets[j].Type == tariff)
                        {
                            passengers[i].Buy(tickets[j]);
                            return;
                        }
                    }
                    Console.WriteLine("Ticket not found");
                    Console.WriteLine("Enter the price: ");
                    AddTicket(Convert.ToInt32(Console.ReadLine()), tariff);
                    passengers[i].Buy(tickets[tickets.Count - 1]);
                    return;
                }
            }
            AddPassenger(passenger_name);
            BuyTicket(passenger_name, type);
            return;
        }

    }
}
