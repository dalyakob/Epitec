using DevTraining.Api.Endpoints.Contacts;
using DevTraining.Api.Endpoints.Contacts.Queries;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace DevTraining.IntegrationTests.Endpoints
{
    public class DeleteEndpoint : IntegrationTest
    {
        public DeleteEndpoint(ApiWebApplicationFactory fixture)
           : base(fixture) { }

        [Fact]
        public async Task DeleteAnExistingContact()
        {
            var content = await _client.GetAsync("api/Contacts");
            content.EnsureSuccessStatusCode();

            var stringContent = await content.Content.ReadAsStringAsync();

            var contacts = JsonSerializer.Deserialize<IEnumerable<GetAllResult>>(stringContent, JsonSerializerHelper.DeserializationOptions);

            var contact = contacts.FirstOrDefault();

            var response = await _client.DeleteAsync($"api/Contacts/{contact.Id}");
            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<DeleteResult>(stringResponse, JsonSerializerHelper.DeserializationOptions);

            result.Should().NotBeNull();
            result.DeletedContactId.Should().Be(contact.Id);
        }
    }
}
