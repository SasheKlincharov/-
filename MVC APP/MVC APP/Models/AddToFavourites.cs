using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_APP.Models
{
    public class AddToFavourites
    {
            public List<CoffeeBar> bars { get; set; }
            public int selectedCoffeeBar { get; set; }
            public AddToFavourites()

            {
                bars = new List<CoffeeBar>();
            }
        }
}