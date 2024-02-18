using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGems.Models
{
    public class Product
    {
        public Guid Id { get; init; }

        public Guid UserId { get; init; }


        public string Name { get; set; }

        public string Description { get; set; }

        public string[] Tags { get; set; }

        public string ImageUrl { get; set; }

        public string ImageId { get; set; }

        public string Location { get; set; }

        public User User { get; init; }

        public ICollection<Like> Likes { get; set; }

        public ICollection<SavePost> SavedPosts { get; set; }

        ICollection<User> Users { get; set; }

        public Product()
        {
            this.Users = new HashSet<User>();
        }


    }
}
