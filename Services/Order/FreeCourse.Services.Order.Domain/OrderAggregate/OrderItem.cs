using FreeCourse.Services.Order.Domain.Core;

namespace FreeCourse.Services.Order.Domain.OrderAggregate
{
    public class OrderItem : Entity
    {
        public string CourseId { get; private set; }
        public string CourseName { get; private set; }
        public string CourseImageUrl { get; private set; }
        public Decimal Price { get; private set; }

        public OrderItem()
        {
        }

        public OrderItem(string productId, string productName, string pictureUrl, decimal price)
        {
            CourseId = productId;
            CourseName = productName;
            CourseImageUrl = pictureUrl;
            Price = price;
        }

        public void UpdateOrderItem(string courseName, string courseImageUrl, decimal price)
        {
            CourseName = courseName;
            Price = price;
            CourseImageUrl = courseImageUrl;
        }
    }
}