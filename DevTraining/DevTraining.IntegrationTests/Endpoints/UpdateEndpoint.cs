using DevTraining.Api.Endpoints.Contacts;
using DevTraining.Api.Endpoints.Contacts.Queries;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace DevTraining.IntegrationTests.Endpoints
{
    public class UpdateEndpoint : IntegrationTest
    {
        public UpdateEndpoint(ApiWebApplicationFactory fixture)
            : base(fixture) { }

        [Fact]
        public async Task UpdateAnExistingContact()
        {
            var content = await _client.GetAsync($"api/Contacts");
            content.EnsureSuccessStatusCode();

            var existingContacts = JsonSerializer.Deserialize<IEnumerable<GetAllResult>>(await content.Content.ReadAsStringAsync(), JsonSerializerHelper.DeserializationOptions);

            content = await _client.GetAsync($"api/Contacts/{existingContacts.FirstOrDefault().Id}");
            content.EnsureSuccessStatusCode();

            var oldContact = JsonSerializer.Deserialize<EditResult>(await content.Content.ReadAsStringAsync(), JsonSerializerHelper.DeserializationOptions);

            var updatedContact = new EditCommand
            {
                Id = oldContact.Id,
                FirstName = "Updated",
                LastName = "Contact",
                PhoneNumber = "0000000000"
            };


            var response = await _client.PutAsync(
                $"api/Contacts", new StringContent(
                    JsonSerializer.Serialize<EditCommand>(
                        updatedContact, JsonSerializerHelper.SerializationOptions), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<EditResult>(stringResponse, JsonSerializerHelper.DeserializationOptions);

            result.Should().NotBeNull();
            result.Id.Should().Be(updatedContact.Id);
            result.FirstName.Should().Be(updatedContact.FirstName);
        }
    }
}
