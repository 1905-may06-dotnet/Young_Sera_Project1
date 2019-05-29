using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBoxDomain
{
    public class DomUser
    {
        public string Username { get; set; }

        public int LocationId { get; set; }

        public string Password { get; set; }

        public DomUser(string username, int locationId, string password)
        {
            Username = username;
            LocationId = locationId;
            Password = password;
        }
    }
}
