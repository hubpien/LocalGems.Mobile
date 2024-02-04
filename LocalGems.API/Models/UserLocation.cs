using Microsoft.CodeAnalysis;

namespace LocalGems.API.Models
{
    public class UserLocation
    {
        public long Id { get; set; }
        public Guid UserId { get; set; }
        public string Long { get; set; }
        public string Lati { get; set; }
    }
}
