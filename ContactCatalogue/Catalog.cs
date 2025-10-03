using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCatalogue
{
    public class Catalog
    {

        Dictionary<int, Contact> contacts = new Dictionary<int, Contact> { };
        HashSet<string> emailsHashset = new HashSet<string> { };
        public bool TryAddContact(Contact contact)
        {
            
             if (contact == null)
            {
                return false;
            }
            // Controlling if Id alredy exist
            if (contacts.ContainsKey(contact.ID) || emailsHashset.Contains(contact.Email))
            {
                return false; // failed to add contact
            }

            contacts.Add(contact.ID, contact);
            emailsHashset.Add(contact.Email);
            return true;
        }
    }
    
}
