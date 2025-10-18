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
            IContactRepository repository = new ContactRepository(logger);
            Catalog catalog = new Catalog(logger,repository);
            var menu = new Menu(catalog);
            menu.ShowMenu();
        }
    }
}
