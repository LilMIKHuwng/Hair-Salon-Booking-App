namespace HairSalon.ModelViews.ComboModelViews
{
    public class ComboModelView
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal TotalPrice { get; set; }
        public int TimeCombo { get; set; }
        public string ComboImage { get; set; }
        public string[]? ServiceIds { get; set; }
    }
}
