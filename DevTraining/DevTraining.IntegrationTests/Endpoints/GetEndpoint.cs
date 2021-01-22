using DevTraining.Api.Endpoints.Contacts.Queries;
using DevTraining.Core.Models;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace DevTraining.IntegrationTests.Endpoints
{
    public class GetEndpoint : IntegrationTest
    {

        public GetEndpoint(ApiWebApplicationFactory fixture)
           : base(fixture) { }

        [Fact]
        public async Task Get_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("api/Contacts/");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task ReturnsContactById()
        {
            //using get all method to retrieve multiple contacts 
            var contacts = await _client.GetFromJsonAsync<IEnumerable<Contact>>($"api/Contacts");
            var contact = contacts.FirstOrDefault();

            var result = await _client.GetFromJsonAsync<Contact>($"api/Contacts/{contact.Id}");

            //asserts
            result.Should().NotBeNull();
            result.Id.Should().Be(contact.Id);
            result.FirstName.Should().Be(contact.FirstName);
            result.LastName.Should().Be(contact.LastName);
            result.PhoneNumber.Should().Be(contact.PhoneNumber);
            result.BirthDate.Should().Be(contact.BirthDate);

        }
    }
}
