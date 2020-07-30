using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;
using BuilderTestSample.Services;
using BuilderTestSample.Tests.TestBuilders;
using Xunit;

namespace BuilderTestSample.Tests
{
    public class OrderServicePlaceOrder
    {
        private readonly OrderService _orderService = new OrderService();
        private readonly OrderBuilder _orderBuilder = new OrderBuilder();
		private readonly CustomerBuilder _customerBuilder = new CustomerBuilder();
		private readonly AddressBuilder _addressBuilder = new AddressBuilder();

        [Fact]
        public void ThrowsExceptionGivenOrderWithExistingId()
        {
            var order = _orderBuilder
                            .Id(123)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionGivenOrderWithAmountLessThanOrEqualToZero()
        {
	        var order = _orderBuilder
		        .Id(0)
		        .Amount(0)
		        .Build();

	        Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionGivenOrderWithoutCustomer()
        {
	        var order = _orderBuilder
		        .Id(0)
		        .Amount(1234)
		        .Customer(null)
		        .Build();

	        Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionGivenOrderCustomerHasIdWithExistingId()
        {
	        var customer = new Customer(0);
	        var order = _orderBuilder
		        .Id(0)
		        .Amount(1234)
		        .Customer(customer)
		        .Build();

	        Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionGivenOrderCustomerWithNoAddress()
        {
	        var customer = _customerBuilder
		        .Id(56)
		        .Address(null)
		        .Build();

	        var order = _orderBuilder
		        .Id(0)
		        .Amount(1234)
		        .Customer(customer)
		        .Build();

	        Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

		[Fact]
		public void ThrowsExceptionGivenOrderCustomerWithNoName()
		{
			var address = new Address();

			var customer = _customerBuilder
				.Id(56)
				.Address(address)
				.Build();

			var order = _orderBuilder
				.Id(0)
				.Amount(1234)
				.Customer(customer)
				.Build();

			Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
		}

		[Fact]
		public void ThrowsExceptionGivenOrderCustomerWithCredit200OrLower()
		{
			var address = new Address();

			var customer = _customerBuilder
				.Id(56)
				.Address(address)
				.Name("Peter", "Parker")
				.CreditRating(100)
				.Build();

			var order = _orderBuilder
				.Id(0)
				.Amount(1234)
				.Customer(customer)
				.Build();

			Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
		}

		[Fact]
		public void ThrowsExceptionGivenOrderCustomerWithPurchasesLessThan0()
		{
			var address = new Address();

			var customer = _customerBuilder
				.Id(56)
				.Address(address)
				.Name("Peter", "Parker")
				.CreditRating(220)
				.TotalPurchases(-5)
				.Build();

			var order = _orderBuilder
				.Id(0)
				.Amount(1234)
				.Customer(customer)
				.Build();

			Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
		}

		[Fact]
		public void ThrowsExceptionGivenAddressWithoutStreet1()
		{
			var address = _addressBuilder
				.Street1(null)
				.City("Taco Town")
				.State("Idaho")
				.PostalCode("12345")
				.Country("USA")
				.Build();

			var customer = _customerBuilder
				.Id(56)
				.Address(address)
				.Name("Peter", "Parker")
				.CreditRating(220)
				.TotalPurchases(32)
				.Build();

			var order = _orderBuilder
				.Id(0)
				.Amount(1234)
				.Customer(customer)
				.Build();

			Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
		}

		[Fact]
		public void ThrowsExceptionGivenAddressWithoutCity()
		{
			var address = _addressBuilder
				.Street1("123 St")
				.Street2("S 1000")
				.City(null)
				.State("Idaho")
				.PostalCode("12345")
				.Country("USA")
				.Build();

			var customer = _customerBuilder
				.Id(56)
				.Address(address)
				.Name("Peter", "Parker")
				.CreditRating(220)
				.TotalPurchases(32)
				.Build();

			var order = _orderBuilder
				.Id(0)
				.Amount(1234)
				.Customer(customer)
				.Build();

			Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
		}

		[Fact]
		public void ThrowsExceptionGivenAddressWithoutState()
		{
			var address = _addressBuilder
				.Street1("123 St")
				.Street2("S 1000")
				.City("Taco Town")
				.State(null)
				.PostalCode("12345")
				.Country("USA")
				.Build();

			var customer = _customerBuilder
				.Id(56)
				.Address(address)
				.Name("Peter", "Parker")
				.CreditRating(220)
				.TotalPurchases(32)
				.Build();

			var order = _orderBuilder
				.Id(0)
				.Amount(1234)
				.Customer(customer)
				.Build();

			Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
		}

		[Fact]
		public void ThrowsExceptionGivenAddressWithoutPostalCode()
		{
			var address = _addressBuilder
				.Street1("123 St")
				.Street2("S 1000")
				.City("Taco Town")
				.State("Idaho")
				.PostalCode(null)
				.Country("USA")
				.Build();

			var customer = _customerBuilder
				.Id(56)
				.Address(address)
				.Name("Peter", "Parker")
				.CreditRating(220)
				.TotalPurchases(32)
				.Build();

			var order = _orderBuilder
				.Id(0)
				.Amount(1234)
				.Customer(customer)
				.Build();

			Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
		}

		[Fact]
		public void ThrowsExceptionGivenAddressWithoutCountry()
		{
			var address = _addressBuilder
				.Street1("123 St")
				.Street2("S 1000")
				.City("Taco Town")
				.State("Idaho")
				.PostalCode("12345")
				.Country(null)
				.Build();

			var customer = _customerBuilder
				.Id(56)
				.Address(address)
				.Name("Peter", "Parker")
				.CreditRating(220)
				.TotalPurchases(32)
				.Build();

			var order = _orderBuilder
				.Id(0)
				.Amount(1234)
				.Customer(customer)
				.Build();

			Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
		}

		[Fact]
		public void ExpediteOrderShouldBeTrue()
		{
			var address = _addressBuilder
				.Street1("123 St")
				.Street2("S 1000")
				.City("Taco Town")
				.State("Idaho")
				.PostalCode("12345")
				.Country("USA")
				.Build();

			var customer = _customerBuilder
				.Id(56)
				.Address(address)
				.Name("Peter", "Parker")
				.CreditRating(564)
				.TotalPurchases(5002)
				.Build();

			var order = _orderBuilder
				.Id(0)
				.Amount(1234)
				.Customer(customer)
				.Build();

			_orderService.PlaceOrder(order);
			Assert.True(order.IsExpedited);
		}

		[Fact]
		public void OrderShouldBeAddedToCustomer()
		{
			var address = _addressBuilder
				.Street1("123 St")
				.Street2("S 1000")
				.City("Taco Town")
				.State("Idaho")
				.PostalCode("12345")
				.Country("USA")
				.Build();

			var customer = _customerBuilder
				.Id(56)
				.Address(address)
				.Name("Peter", "Parker")
				.CreditRating(564)
				.TotalPurchases(5002)
				.Build();

			var order = _orderBuilder
				.Id(0)
				.Amount(1234)
				.Customer(customer)
				.Build();

			_orderService.PlaceOrder(order);
			Assert.True(customer.OrderHistory.Count == 1);
		}

		[Fact]
		public void OrderTotalPurchasesShouldBeCorrect()
		{
			var address = _addressBuilder
				.Street1("123 St")
				.Street2("S 1000")
				.City("Taco Town")
				.State("Idaho")
				.PostalCode("12345")
				.Country("USA")
				.Build();

			var customer = _customerBuilder
				.Id(56)
				.Address(address)
				.Name("Peter", "Parker")
				.CreditRating(564)
				.TotalPurchases(5002)
				.Build();

			var order = _orderBuilder
				.Id(0)
				.Amount(1234)
				.Customer(customer)
				.Build();

			_orderService.PlaceOrder(order);
			Assert.True(customer.TotalPurchases == 5003);
		}
	}
}
