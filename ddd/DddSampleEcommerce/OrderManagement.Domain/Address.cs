namespace OrderManagement.Domain
{
    public class Address
    {
        public string AddressLine1 { get; }
        public string AddressLine2 { get; }
        public string Country { get; }

        private Address(string addressLine1, string addressLine2, string country)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            Country = country;
        }
        public static Address Create(string addressLine1, string addressLine2, string country)
        {
            return new Address(addressLine1, addressLine2, country);
        }

    }
}
