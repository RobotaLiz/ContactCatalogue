using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCatalogue
{
    public static class InputHandler
    {

        public static int GetId()
        {
            while (true)
            {

                Console.Write("Skriv in ett id: ");
                var idInput = Console.ReadLine();
                if (int.TryParse(idInput, out int id))
                {
                    return id;
                }
                else
                {
                    Console.WriteLine($"Ogiltigt Id ({idInput}) endast siffror, prova igen.");
                }

            }

        }
        public static string GetEmail()
        {

            while (true)
            {

                try
                {

                    Console.Write("Skriv in email: ");
                    var emailInput = Console.ReadLine();
                    var email = new System.Net.Mail.MailAddress(emailInput!); // the constuctor throws an exception if the email is invalid.
                    var checkInvalidCharacter = new List<char>
                    {
                        'å','ä','ö'
                    };
                    foreach (var c in checkInvalidCharacter)
                    {
                        if (email.Address.Contains(c))
                        {
                            throw new InvalidEmailException($"{c} - is invalid when user write with å,ä,ö");
                        }
                    }
                    return email.Address.ToLower();
                }
                catch (InvalidEmailException)
                {
                    Console.WriteLine("(å,ä,ö) är ej tillåten inmatning, prova igen");
                }

                catch
                {
                    Console.WriteLine("Fel inmatning av email, prova igen");
                }


            }


        }
    }
}
