namespace FreeCourse.Web.Models
{
    public class ServiceApiSettings
    {
        internal object GatewayBaseUrl;

        public string BaseUrl { get; set; }
        public string GatewayUrl { get; set; }
        public string PhotoStockUrl { get; set; }
        public ServiceApi Catalog { get; set; }
        public ServiceApi PhotoStock { get; set; }
        public ServiceApi Basket { get; set; }
        public ServiceApi Discount { get; set; }
    }

    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
