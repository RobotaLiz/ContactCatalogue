using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCatalogue
{
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Tags { get; set; }


        public Contact(int id, string name, string email, string tags)
        {
            ID = id;
            Name = name;
            Email = email;
            Tags = tags;
        }

    }
}
