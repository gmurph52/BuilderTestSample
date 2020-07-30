using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
    /// <summary>
    /// Reference: https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
    /// </summary>
    public class AddressBuilder
    {
        private Address _address = new Address();

        public AddressBuilder Street1(string street1)
        {
	        _address.Street1 = street1;
            return this;
        }

        public AddressBuilder Street2(string street2)
        {
	        _address.Street2 = street2;
	        return this;
        }

        public AddressBuilder Street3(string street3)
        {
	        _address.Street3 = street3;
	        return this;
        }

        public AddressBuilder City(string city)
        {
	        _address.City = city;
	        return this;
        }

        public AddressBuilder State(string state)
        {
	        _address.State = state;
	        return this;
        }

        public AddressBuilder PostalCode(string postalCode)
        {
	        _address.PostalCode = postalCode;
	        return this;
        }

        public AddressBuilder Country(string country)
        {
	        _address.Country = country;
	        return this;
        }

        public Address Build()
        {
            return _address;
        }

    }
}
