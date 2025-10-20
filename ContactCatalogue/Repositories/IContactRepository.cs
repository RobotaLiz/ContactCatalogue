using ContactCatalogue.Models;

namespace ContactCatalogue.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAll();
        bool TryAddContact(Contact contact);
    }
}

