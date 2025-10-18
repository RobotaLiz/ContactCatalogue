using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCatalogue
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAll();
        bool TryAddContact(Contact c);
    }
}

