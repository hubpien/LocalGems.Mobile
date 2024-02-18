﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGems.Models
{
    public class Like
    {
        public Guid PostId { get; set; }
        public Product Post { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
