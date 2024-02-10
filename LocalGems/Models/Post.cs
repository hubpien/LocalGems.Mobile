using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGems.Models
{
    public class Post
    {
        public Guid Id { get; init; }

        public Guid UserId { get; init; }


        public string Description { get; set; }

        public string Tags { get; set; }

        public string ImageUrl { get; set; }

        public string ImageId { get; set; }

        public string Location { get; set; }

        public User User { get; init; }

        public ICollection<Like> Likes { get; set; }

        public ICollection<SavePost> SavedPosts { get; set; }

        ICollection<User> Users { get; set; }

        public Post()
        {
            this.Users = new HashSet<User>();
        }


    }
}
