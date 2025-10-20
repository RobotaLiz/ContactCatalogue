using ContactCatalogue.Handlers;
using ContactCatalogue.Models;

namespace ContactCatalogue
{
    public class Menu
    {
        public CatalogService Catalog { get; set; }

        public Menu(CatalogService catalog)
        {
            Catalog = catalog;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("   -----MENY-----");
                Console.WriteLine("Välj ett alternativ?");
                Console.WriteLine("1, Lägg till kontakt");
                Console.WriteLine("2, Sök kontakt med email eller namn");
                Console.WriteLine("3, Sök kontakt med tagg");
                Console.WriteLine("4, Lista alla kontakter");
                Console.WriteLine("5, Exportera till CSV-fil");


                var input = Console.ReadLine();


                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:


                            Console.WriteLine("Lägg till kontakt\n");
                            Console.Write("Namn: ");
                            var name = Console.ReadLine();
                            var idInput = InputHandler.GetId();
                            var email = InputHandler.GetEmail();
                            Console.Write("Taggar: ");
                            var tags = Console.ReadLine();

                            var contact = new Contact(idInput, name, email, tags);

                            if (Catalog.TryAddContact(contact))
                            {
                                Console.WriteLine("Kontakt tillagd!");
                            }
                            else
                            {
                                Console.WriteLine("Kontakten existerar redan!");
                            }

                            break;

                        case 2:
                            Console.Write("Ange email eller namn: ");
                            Catalog.SearchByNameOrEmail(Console.ReadLine());

                            break;
                        case 3:
                            Console.Write("Söka efter tagg: ");
                            Catalog.SearchByTag(Console.ReadLine());
                            break;
                        case 4:
                            Console.Write("Lista alla kontakter: ");
                            var sorted = Catalog.ListContactsByName();
                            Console.Clear();
                            foreach (var c in sorted)
                            {

                                Console.WriteLine($"{c.Name} - Id: ({c.ID}) - <{c.Email}> - taggar: [{c.Tags}]");

                            }
                            break;

                        case 5:
                            Console.WriteLine("Exportera till CSV-fil");
                            Catalog.ExportCsvFile();
                            break;


                        default: // If you enter a choice that doesn´t exist, the default case is run instead and gives a message.
                            Console.Clear();
                            Console.WriteLine($"fel inmatning, {choice}: ej giltig, försök igen! ");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Inmatning felaktig ({input}), Vänligen försök igen.\n"); // If the input is not an interger. 
                }

            }
        }
    }
}
