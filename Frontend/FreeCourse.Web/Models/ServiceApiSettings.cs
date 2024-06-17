namespace FreeCourse.Web.Models
{
    public class ServiceApiSettings
    {
        public string BaseUrl { get; set; }
        public string GatewayUrl { get; set; }
        public string PhotoStockUrl { get; set; }
        public ServiceApi Catalog { get; set; }
    }

    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
