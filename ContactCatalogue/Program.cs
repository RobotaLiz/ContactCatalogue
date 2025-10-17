using Microsoft.Extensions.Logging;


namespace ContactCatalogue
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger logger = loggerFactory.CreateLogger<Program>();

            InputHandler.Logger = logger;
            var menu = new Menu(new Catalog(logger));
            menu.ShowMenu();


         


        }
    }
}
