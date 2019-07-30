using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavigationProperty.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int TeamID { get; set; }
        public Team Team { get; set; }
    }
}