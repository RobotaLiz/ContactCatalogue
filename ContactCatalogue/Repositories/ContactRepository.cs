using ContactCatalogue.Exceptions;
using ContactCatalogue.Models;
using Microsoft.Extensions.Logging;

namespace ContactCatalogue.Repositories
{
    public class ContactRepository : IContactRepository
    {
        Dictionary<int, Contact> contacts = new Dictionary<int, Contact> { };
        HashSet<string> emailsHashset = new HashSet<string> { };
        ILogger Logger;
        public ContactRepository(ILogger logger)
        {
            Logger = logger;
        }
        public IEnumerable<Contact> GetAll()
        {
            return contacts.Select(kv => kv.Value).ToList();
        }

        public bool TryAddContact(Contact contact)
        {
            if (contact == null)
            {
                return false;
            }
            // Controlling if Id or email already exist
            if (contacts.ContainsKey(contact.ID) || emailsHashset.Contains(contact.Email))
            {
                try
                {
                    throw new DuplicateException("This id or Email already exist.");
                }
                catch
                {
                    Logger.LogError("Invalid email or id, already exist");
                    Console.WriteLine("Denna email eller id finns redan");
                    return false;

                }


            }

            contacts.Add(contact.ID, contact);
            emailsHashset.Add(contact.Email);
            return true;
        }
    }
}
