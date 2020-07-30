﻿using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
    /// <summary>
    /// Reference: https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
    /// </summary>
    public class OrderBuilder
    {
        private Order _order = new Order();

        public OrderBuilder Id(int id)
        {
            _order.Id = id;
            return this;
        }

        public OrderBuilder Amount(decimal amount)
        {
	        _order.TotalAmount = amount;
	        return this;
        }

        public OrderBuilder Customer(Customer customer)
        {
	        _order.Customer = customer;
	        return this;
        }

        public Order Build()
        {
            return _order;
        }

        //public OrderBuilder WithTestValues()
        //{
        //    _order.TotalAmount = 100m;

        //    return this;
        //}
    }
}
