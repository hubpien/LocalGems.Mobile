namespace LocalGems.API.Models
{
    public class UserOffer
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public int? Status { get; set; }

    }
}