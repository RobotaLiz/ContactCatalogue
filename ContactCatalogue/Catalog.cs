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
                return false; // failed to add contact, it already exist!
            } 

            contacts.Add(contact.ID, contact);
            emailsHashset.Add(contact.Email);
            return true;
        }
        public void ListContactsByName()
        {
            var sorted = contacts.OrderBy(c => c.Value.Name);
            Console.Clear();
            foreach (var contact in sorted)
            {

                Console.WriteLine($"{contact.Value.Name} - Id:({contact.Value.ID}) - <{contact.Value.Email}> - taggar:[{contact.Value.Tags}]");
               
            }

        }
        public void SearchByNameOrEmail(string search)
        {
            var result = contacts.Where(s => s.Value.Name.Contains(search) || s.Value.Email.Contains(search));

            foreach(var keyValue in result )
            {
                Console.WriteLine($"Hittade namn: { keyValue.Value.Name} - Email: ({keyValue.Value.Email})");

            }
        }
        public void SearchByTag(string tag)
        {
            var FoundTag = contacts.OrderBy(t => t.Value.Tags)
                .Where(t => t.Value.Tags.Contains(tag));

            Console.WriteLine("Search result by tag");
            foreach(var kvp in FoundTag)
            {
                Console.WriteLine($"\tNamn:{kvp.Value.Name} Email:{kvp.Value.Email} Tag:{kvp.Value.Tags}  ");
            }
            
        }
        
    }
    
}
