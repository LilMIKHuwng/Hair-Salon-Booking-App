namespace HairSalon.ModelViews.ComboModelViews
{
    public class UpdateComboModelView
    {
        public string? Name { get; set; } // Không có thuộc tính [Required]
        public List<string> ServiceIdsToAdd { get; set; } = new List<string>();
        public List<string> ServiceIdsToRemove { get; set; } = new List<string>();
    }
}
