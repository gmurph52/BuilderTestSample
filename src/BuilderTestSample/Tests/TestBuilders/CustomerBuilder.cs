using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
    /// <summary>
    /// Reference: https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
    /// </summary>
    public class CustomerBuilder
    {
        private Customer _customer;

        public CustomerBuilder Id(int id)
        {
	        _customer = new Customer(id);
            return this;
        }

        public CustomerBuilder Address(Address address)
        {
	        _customer.HomeAddress = address;
	        return this;
        }

        public CustomerBuilder Name(string firstname, string lastname)
        {
	        _customer.FirstName = firstname;
	        _customer.LastName = lastname;
	        return this;
        }

        public CustomerBuilder CreditRating(int creditRating)
        {
	        _customer.CreditRating = creditRating;
	        return this;
        }

        public CustomerBuilder TotalPurchases(int totalPurchases)
        {
	        _customer.TotalPurchases = totalPurchases;
	        return this;
        }

        public Customer Build()
        {
            return _customer;
        }

    }
}
