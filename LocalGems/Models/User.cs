namespace LocalGems.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public Location Location { get; set; }
        public Color Color { get; set; }
    }
}