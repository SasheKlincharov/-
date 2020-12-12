using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_APP.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}