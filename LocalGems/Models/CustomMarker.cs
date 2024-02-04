using Syncfusion.Maui.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGems.Models
{
    public class CustomMarker : MapMarker
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public CustomMarker() { }

    }
}
