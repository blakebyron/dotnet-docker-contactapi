using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contact.Api.Features.Contact;
using Xunit;

namespace Contact.FunctionalTests.Features.Contact
{
    [Collection("Database")]
    public class ContactControllerTests:IClassFixture<ContactApiWebApplicationFactory>
    {
        private ContactApiWebApplicationFactory appFactory;

        public ContactControllerTests(ContactApiWebApplicationFactory appFactory)
        {
            this.appFactory = appFactory;
        }

        [Fact]
        public async Task ShouldListContact()
        {
            //Arrange
            var client = appFactory.CreateClient();
            // Act
            var clientResponse = await client.GetAsync("/contacts");
            clientResponse.EnsureSuccessStatusCode();

            var listResponse = await clientResponse.Content.ReadAsJsonAsync<List<List.Result.Contact>>();

            //Assert
            Assert.True(listResponse.Count() > 0);
        }
    }

    [CollectionDefinition("Database")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {

    }
}
