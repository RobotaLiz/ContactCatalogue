using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
            // Controlling if Id or email already exist
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

                Console.WriteLine($"{contact.Value.Name} - Id: ({contact.Value.ID}) - <{contact.Value.Email}> - taggar: [{contact.Value.Tags}]");
               
            }

        }
        public void SearchByNameOrEmail(string search)
        {
            var result = contacts.Where(s => 
            s.Value.Name.Contains(search, StringComparison.OrdinalIgnoreCase) || s.Value.Email.Contains(search, StringComparison.OrdinalIgnoreCase))
                .OrderBy(c => c.Value.Name);

            foreach(var keyValue in result )
            {
                Console.WriteLine($"Hittade namn: { keyValue.Value.Name} - Email: ({keyValue.Value.Email}) - Taggar: {keyValue.Value.Tags}");

            }
        }
        public void SearchByTag(string tag)
        {
            var FoundTag = contacts.OrderBy(t => t.Value.Tags)
                .Where(t => t.Value.Tags.Contains(tag, StringComparison.OrdinalIgnoreCase)).ToList();

            Console.WriteLine("Sökresultat via tag ");
            foreach(var kvp in FoundTag)
            {
                Console.WriteLine($"\tNamn: {kvp.Value.Name} Email: {kvp.Value.Email} Tag: {kvp.Value.Tags}  ");
            }
            
        }
        public void ExportCsvFile()
        {
            var sBuilder = new StringBuilder();
            sBuilder.AppendLine("Id,Name,Email,Tags"); // Create the header for the CVS-file
            foreach(var c in contacts)
            {
                sBuilder.AppendLine($"{c.Value.ID},{c.Value.Name},{c.Value.Email},{c.Value.Tags}");


            }
            File.WriteAllText("C:\\CSV\\Contacts.csv", sBuilder.ToString());
            Console.WriteLine("Alla kontankter är exporterade till C:\\CSV\\Contacts.csv");

        }
        
    }
    
}

