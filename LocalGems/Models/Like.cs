using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGems.Models
{
    public class Like
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }


        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
