using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCatalogue
{
    public class Menu
    {
        public Catalog Catalog { get; set; }

        public Menu(Catalog catalog)
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
                Console.WriteLine("2, Sök namn");
                Console.WriteLine("3, sök tagg");
                Console.WriteLine("4, Lista alla kontakter");


                var input = Console.ReadLine();


                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:


                            Console.WriteLine("Lägg till kontakt\n");
                            Console.WriteLine("Namn:");
                            var name = Console.ReadLine();
                            Console.WriteLine("ID:");
                            var idInput = InputHandler.GetId();

                            Console.WriteLine("E-post");
                            var email = InputHandler.GetEmail();
                            Console.WriteLine("Taggar");
                            var tags = Console.ReadLine();

                            var contact = new Contact(idInput, name, email, tags);

                            if (Catalog.TryAddContact(contact))
                            {
                                Console.WriteLine("Kontakt tillagd!");
                                break;

                            }

                            break;

                        case 2:
                            Console.WriteLine("Söka kontakt");
                            Catalog.SearchByNameOrEmail(Console.ReadLine());

                            break;
                        case 3:
                            Console.WriteLine("Söka efter tagg");
                            Catalog.SearchByTag(Console.ReadLine());
                            break;
                        case 4:
                            Console.WriteLine("Lista alla kontakter");
                            Catalog.ListContactsByName();
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
