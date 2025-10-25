using ContactCatalogue.Handlers;
using ContactCatalogue.Repositories;
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

            CatalogService catalog = new CatalogService(logger,repository);
            var menu = new Menu(catalog);
            menu.ShowMenu();
        }
    }
}
