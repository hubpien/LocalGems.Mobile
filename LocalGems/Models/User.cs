using LocalGems.ViewModels;

namespace LocalGems.Models
{
    public class User
    {
        private Guid _Id;

        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string? _Name;

        public string? Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string? _Description;

        public string? Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private UserType _Type;

        public UserType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }


        private string? _Category;

        public string? Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        private string? _Image;

        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }


        private Color? _Color;

        public Color Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        private CustomMarker? _Location;

        public CustomMarker Location
        {
            get { return _Location; }
            set { _Location = value; }
        }


    }
}