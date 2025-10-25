using ContactCatalogue.Models;
using ContactCatalogue.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace ContactCatalogue.Tests
{
    public class ContactCatalogTests
    {
        [Fact]
        public void Can_Add_Contact()
        {
            // Arrange
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger logger = loggerFactory.CreateLogger<Program>();
            IContactRepository repository = new ContactRepository(logger);
            var catalogue = new CatalogService(logger, repository);

            // Act
            var c1 = new Contact(123,"Bertil","Bertil@hotmail.com","Programmerare");
            var wasAdded = catalogue.TryAddContact(c1);

            // Assert
            Assert.True(wasAdded);
        }

        [Fact]
        public void Cant_Add_Duplicate_Contact()
        {
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger logger = loggerFactory.CreateLogger<Program>();
            IContactRepository repository = new ContactRepository(logger);
            var catalogue = new CatalogService(logger, repository);


            var c1 = new Contact(123, "Bertil", "Bertil@hotmail.com", "Programmerare");
            var wasAdded = catalogue.TryAddContact(c1);
            var wasAdded1 = catalogue.TryAddContact(c1);

            Assert.False(wasAdded1);
        }
        [Fact]
        public void ListContactsByName_Is_Sorted()
        {
            // Arrange
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger logger = loggerFactory.CreateLogger<Program>();
            IContactRepository repository = new ContactRepository(logger);
            var catalogue = new CatalogService(logger, repository);

            var z1 = new Contact(123, "Zelda", "adam@hotmail.com", "Programmerare");
            var c1 = new Contact(126, "Adam", "zelda@hotmail.com", "Programmerare");
            var c2 = new Contact(124, "Bertil", "Bertil@hotmail.com", "Programmerare");

            var wasAdded = catalogue.TryAddContact(c1);
            var wasAdded1 = catalogue.TryAddContact(c2);
            var wasAddedz1 = catalogue.TryAddContact(z1);

            //Act
            var sortedList = catalogue.ListContactsByName();

            Assert.True(sortedList[0].Name == "Adam");
            Assert.True(sortedList[2].Name == "Zelda");
        }
        [Fact]
        public void Filter_By_Tag_Returns_Only_Matching()
        {
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger logger = loggerFactory.CreateLogger<Program>();
            IContactRepository repository = new ContactRepository(logger);

            var mock = new Mock<IContactRepository>();
            mock.Setup(r => r.GetAll()).Returns(new[]
            {
                new Contact(123, "Zelda", "zelda@hotmail.com", "Programmerare"),
                new Contact(126, "Adam", "adam@hotmail.com", "Worker")
            });

            var catalog = new CatalogService(logger, mock.Object);
            var result = catalog.SearchByTag("Programmerare").ToList();

            Assert.Single(result);
            Assert.Equal("Zelda", result[0].Name);
        }
    }
}