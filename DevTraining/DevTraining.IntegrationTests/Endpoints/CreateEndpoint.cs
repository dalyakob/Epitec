using DevTraining.Api.Endpoints.Contacts;
using DevTraining.Core.Models;
using FluentAssertions;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace DevTraining.IntegrationTests.Endpoints
{
    public class CreateEndpoint : IntegrationTest
    { 
                       
        public CreateEndpoint(ApiWebApplicationFactory fixture)
            : base(fixture) { }

        [Fact]
        public async Task CreatesNewContact()
        {
            var newContact = new CreateCommand()
            {
                FirstName = "James",
                LastName = "Eastham",
                PhoneNumber = "3139997777"
            };

            var content = new StringContent(JsonSerializer.Serialize(newContact, JsonSerializerHelper.SerializationOptions), Encoding.UTF8, "application/json");

           
            var response = await _client.PostAsync("api/Contacts/", content);

            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Contact>(stringResponse, JsonSerializerHelper.DeserializationOptions);


            result.Should().NotBeNull();
            result.Id.Should().NotBe(Guid.Empty);
            result.FirstName.Should().Be(newContact.FirstName);
        }
    }
}
