﻿using FreeCourse.Services.Order.Domain.Core;

namespace FreeCourse.Services.Order.Domain.OrderAggregate
{
    //EF Core features
    // -- Owned Types
    // -- Shadow Property
    // -- Backing Field
    public class Order : Entity, IAggregateRoot
    {
        public DateTime CreatedDate { get; private set; }

        public Address Address { get; private set; }

        public string BuyerId { get; private set; }

        private readonly List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order()
        {
        }

        public Order(string buyerId, Address address)
        {
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
            Address = address;
        }

        public void AddOrderItem(string courseId, string courseName, decimal price, string courseImageUrl)
        {
            var existProduct = _orderItems.Any(x => x.CourseId == courseId);

            if (!existProduct)
            {
                var newOrderItem = new OrderItem(courseId, courseName, courseImageUrl, price);

                _orderItems.Add(newOrderItem);
            }
        }

        public decimal GetTotalPrice => _orderItems.Sum(x => x.Price);
    }
}