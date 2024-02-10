namespace LocalGems.API.Models
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

        public ICollection<Like> Likes { get; set; } = new List<Like>();

        public ICollection<SavePost> SavedPosts { get; set; } = new List<SavePost>();

        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

        public Post()
        {
            this.Users = new HashSet<ApplicationUser>();
            this.Likes = new HashSet<Like>();
            this.SavedPosts = new HashSet<SavePost>();
        }


    }
}
