using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_APP.Models
{
    public class AddToFavourites
    {
        public class AddToStore
        {
            public List<CaffeBar> bars { get; set; }
            public int selectedCaffeBar { get; set; }
            public AddToStore()

            {
                bars = new List<CaffeBar>();
            }
        }
    }
}