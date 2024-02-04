using Microsoft.AspNetCore.Identity;

namespace LocalGems.API.Models
{
    public class ApplicationUser
    {
        public ApplicationUser()
        {
            this.Posts = new HashSet<Post>();
        }
        public int Id { get; set; }
        
        public string Description { get; set; }
        public byte[] Photo { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
