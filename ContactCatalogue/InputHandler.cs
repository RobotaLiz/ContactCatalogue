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

                Console.WriteLine("Skriv in ett Id:");
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

                    Console.WriteLine("Skriv in EmailAdress:");
                    var emailInput = Console.ReadLine();
                    var email = new System.Net.Mail.MailAddress(emailInput!); // the constuctor throws an exception if the email is invalid.
                    return email.Address;
                }
                catch { Console.WriteLine("Fel inmatning av email, prova igen"); }


            }


        }
    }
}
