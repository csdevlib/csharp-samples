using System;

namespace OrderManagement.Domain
{
    public class TransitLocation
    {
        public string Name { get; }
        public DateTime Date { get; }
        public Address Address { get; }

        private TransitLocation(string name, DateTime date, Address address)
        {
            Name = name;
            Date = date;
            Address = address;
        }

        public static TransitLocation Create(string name, DateTime date, Address address)
        {
            return new TransitLocation(name, date, address);
        }
    }
}
