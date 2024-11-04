namespace HairSalon.ModelViews.ServiceModelViews
{
    public class ServiceModelView
    {
        public string Id { get; set; }

        public string Name {  get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public int TimeService { get; set; }

        public string ShopId { get; set; }

        public string ServiceImage { get; set; }
    }
}
