using Newtonsoft.Json;
using System;

namespace OrderManagement.Contracts.Common
{
    public class TransitLocation
    {
        public string Name { get; }
        public DateTime Date { get; }
        public Address Address { get; }

        [JsonConstructor]
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
