using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;

namespace BuilderTestSample.Services
{
    public class OrderService
    {
        public void PlaceOrder(Order order)
        {
            ValidateOrder(order);

            ExpediteOrder(order);

            AddOrderToCustomerHistory(order);
        }

        private void ValidateOrder(Order order)
        {
            // throw InvalidOrderException unless otherwise noted.
            if (order.Id != 0) throw new InvalidOrderException("Order ID must be 0.");
            if (order.TotalAmount <= 0) throw new InvalidOrderException("Order amount must be more than 0.");
            if (order.Customer == null) throw new InvalidOrderException("Order must have a customer.");

            ValidateCustomer(order.Customer);
        }

        private void ValidateCustomer(Customer customer)
        {
            // throw InvalidCustomerException unless otherwise noted
            // create a CustomerBuilder to implement the tests for these scenarios

            if (customer.Id <= 0) throw new InvalidCustomerException("Customer must have an ID greater than 0");
            if (customer.HomeAddress == null) throw new InvalidCustomerException("Customer must have an Address");
            if (customer.FirstName == null || customer.LastName == null) throw new InvalidCustomerException("Customer must have a first and last name.");
            if (customer.CreditRating <= 200) throw new InvalidCustomerException("Customer must have a credit rating greater than 200.");
            if (customer.TotalPurchases < 0) throw new InvalidCustomerException("Customer must have total purchases greater than 0.");
            
            ValidateAddress(customer.HomeAddress);
        }

        private void ValidateAddress(Address homeAddress)
        {
            // throw InvalidAddressException unless otherwise noted
            // create an AddressBuilder to implement the tests for these scenarios
            if (string.IsNullOrEmpty(homeAddress.Street1)) throw new InvalidAddressException("Street1 is required");
            if (string.IsNullOrEmpty(homeAddress.City)) throw new InvalidAddressException("City is required");
            if (string.IsNullOrEmpty(homeAddress.State)) throw new InvalidAddressException("State is required");
            if (string.IsNullOrEmpty(homeAddress.PostalCode)) throw new InvalidAddressException("PostalCode is required");
            if (string.IsNullOrEmpty(homeAddress.Country)) throw new InvalidAddressException("Country is required");
        }

        private void ExpediteOrder(Order order)
        {
            if (order.Customer.TotalPurchases > 5000 && order.Customer.CreditRating > 500)
            {
	            order.IsExpedited = true;
            }
        }

        private void AddOrderToCustomerHistory(Order order)
        {
            order.Customer.OrderHistory.Add(order);
            order.Customer.TotalPurchases++;
        }
    }
}
