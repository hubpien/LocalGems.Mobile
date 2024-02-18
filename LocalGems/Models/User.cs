using LocalGems.ViewModels;

namespace LocalGems.Models
{
    public partial class User : ObservableObject
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public UserType Type { get; set; }

        public string? Category { get; set; }

        public string? Image { get; set; }

        public Color? Color { get; set; }

        public List<CustomMarker> Location { get; set; }

        public List<Product> Products { get; set; }

        public int Views { get; set; }

        [ObservableProperty]
        private bool isFavorite;

    }
}