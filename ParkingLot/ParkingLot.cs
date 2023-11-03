﻿namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private readonly int capacity = 10;
        private readonly HashSet<string> usedTickets = new HashSet<string>();
        private readonly Dictionary<string, string> ticketCarMap = new Dictionary<string, string>();
        private int parkingCount = 0;

        public string Park(string carNumber)
        {
            if (parkingCount >= capacity)
            {
                Console.WriteLine("No available position.");
                return null;
            }

            var ticket = Guid.NewGuid().ToString();
            ticketCarMap[ticket] = carNumber;
            parkingCount++;

            return ticket;
        }

        public string FetchCar(string ticket = null)
        {
            if (ticket == null)
            {
                return null;
            }

            if (!ticketCarMap.ContainsKey(ticket) || usedTickets.Contains(ticket))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            usedTickets.Add(ticket);
            parkingCount--;

            return ticketCarMap[ticket];
        }
    }
}
