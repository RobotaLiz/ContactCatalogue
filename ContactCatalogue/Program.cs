namespace ContactCatalogue
{
    public class Program
    {
        static void Main(string[] args)
        {

            var menu = new Menu(new Catalog());
            menu.ShowMenu();


            // fixa exportering från CSV
            // validera email, fixa så du inte kan skriva samma mail med lite bokstav
            // Loggning via Microsoft.Extensions.Logging (ConsoleLogger).


        }
    }
}
