using DevTraining.Api.Endpoints.Contacts.Queries;
using DevTraining.Core.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace DevTraining.IntegrationTests.Endpoints
{
    public class GetAllEndpoint : IntegrationTest
    {

        public GetAllEndpoint(ApiWebApplicationFactory fixture)
           : base(fixture) { }

        [Fact]
        public async Task GetAll_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("api/Contacts");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetAll_ReturnsContacts()
        {
            var contacts = await _client.GetFromJsonAsync<List<Contact>>("api/Contacts");

            //var content = await response.Content.ReadAsStringAsync();
            //var contacts = JsonSerializer.Deserialize<IEnumerable<GetAllResult>>(content, JsonSerializerHelper.DeserializationOptions);

            contacts.Should().NotBeNull();
            contacts.Count().Should( ).BeGreaterThan(1);

            contacts[0].Id.Should().NotBe(Guid.Empty);
            contacts[0].FirstName.Should().NotBeNullOrEmpty();

            contacts[^1].Id.Should().NotBe(Guid.Empty);
            contacts[^1].FirstName.Should().NotBeNullOrEmpty();

        }

    }
}
