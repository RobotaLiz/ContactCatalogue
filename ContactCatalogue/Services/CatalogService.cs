using ContactCatalogue.Models;
using ContactCatalogue.Repositories;
using Microsoft.Extensions.Logging;
using System.Text;


namespace ContactCatalogue
{
    public class CatalogService
    {
        ILogger Logger;
        IContactRepository Repository;

        public CatalogService(ILogger logger, IContactRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }

        public bool TryAddContact(Contact contact)
        {
            return Repository.TryAddContact(contact);
        }

        public List<Contact> ListContactsByName()
        {
            var sorted = Repository.GetAll().OrderBy(c => c.Name).ToList();
            
            return sorted;
        }


        public List<Contact> SearchByNameOrEmail(string search)
        {
            var result = Repository.GetAll().Where(s =>
            s.Name.Contains(search, StringComparison.OrdinalIgnoreCase) || s.Email.Contains(search, StringComparison.OrdinalIgnoreCase))
                .OrderBy(c => c.Name).ToList();

            foreach (var contact in result)
            {
                Console.WriteLine($"Hittade namn: {contact.Name} - Email: ({contact.Email}) - Taggar: {contact.Tags}");

            }
            return result;
        }

        public List<Contact> SearchByTag(string tag)
        {
            var FoundTag = Repository.GetAll().OrderBy(t => t.Tags)
               .Where(t => t.Tags.Contains(tag, StringComparison.OrdinalIgnoreCase)).ToList();

            Console.WriteLine("Sökresultat via tag ");
            foreach (var contact in FoundTag)
            {
                Console.WriteLine($"\tNamn: {contact.Name} Email: {contact.Email} Tag: {contact.Tags}  ");
            }
            return FoundTag;
        }

        public void ExportCsvFile()
        {
            var sBuilder = new StringBuilder();
            sBuilder.AppendLine("Id,Name,Email,Tags"); // Create the header for the CVS-file

            var allContacts = Repository.GetAll().ToList();

            if (allContacts.Count == 0)
            {
                Logger.LogInformation("User tried to export an empty contact list");
                return;
            }

            foreach (var c in allContacts)
            {
                sBuilder.AppendLine($"{c.ID},{c.Name},{c.Email},{c.Tags}");
            }
            var path = "C:\\CSV\\Contacts.csv";
            try
            {
                File.WriteAllText(path, sBuilder.ToString());
                Logger.LogInformation("CSV-file added to disk");
                Console.WriteLine($"Alla kontankter är exporterade till {path}");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Could not write file to {path} ");
            }

        }

    }

}

