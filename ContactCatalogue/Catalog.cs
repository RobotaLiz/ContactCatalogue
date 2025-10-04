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
        public void ListContactsByName()
        {
            var sorted = contacts.OrderBy(c => c.Value.Name);

            foreach (var contact in sorted)
            {
                Console.WriteLine(contact.Value.Name);
            }

        }
        public void SearchByName(string search)
        {
            var result = contacts.Where(s => s.Value.Name.Contains(search));

            foreach(var keyValue in result )
            {
                Console.WriteLine($"Namn hittad vid sökning: { keyValue.Value.Name}");
            }
        }
        
    }
    
}
