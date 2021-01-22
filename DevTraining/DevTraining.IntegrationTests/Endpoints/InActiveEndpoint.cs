using DevTraining.Api.Endpoints.Contacts.Commands;
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
    public class InActivateEnpoint : IntegrationTest
    {
        public InActivateEnpoint(ApiWebApplicationFactory fixture)
            : base(fixture) { }

        [Fact]
        public async Task DeactivateContact()
        {
            var content = await _client.GetAsync($"api/Contacts");
            content.EnsureSuccessStatusCode();

            var contacts = JsonSerializer.Deserialize<IEnumerable<GetAllResult>>(await content.Content.ReadAsStringAsync(), JsonSerializerHelper.DeserializationOptions);

            var contact = contacts.FirstOrDefault();

            var response = await _client.PutAsync($"api/Contacts/{contact.Id}", new StringContent(JsonSerializer.Serialize<GetAllResult>(contact, JsonSerializerHelper.SerializationOptions), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<InActivateResult>(stringResponse, JsonSerializerHelper.DeserializationOptions);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(contact.Id);
            result.FirstName.Should().Be(contact.FirstName);
            result.InActivatedDate.Should().NotBeNull();
            result.IsActive.Should().Be(false);
        }
    }
}
