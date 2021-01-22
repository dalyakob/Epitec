//using DevTraining.Endpoints.Contacts;
//using DevTraining.Models;
//using FluentAssertions;
//using Newtonsoft.Json;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace DevTraining.IntegrationTests
//{
//    public class ContactsControllerTests : IntegrationTest
//    {
//        public ContactsControllerTests(ApiWebApplicationFactory fixture)
//            : base(fixture) { }

//        [Fact]
//        public async Task Post_Should_ResultInCreated()
//        {
//            var contact = new Contact { FirstName = "Bob", LastName = "Jonson", PhoneNumber = "9998887777" };
//            var response = await _client.PostAsync("Contacts",
//                new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json"));

//            response.StatusCode.Should().Be(HttpStatusCode.Created);
//        }

//        [Fact]
//        public async Task Put_Should_ResultInNoContent()
//        {
//            var contact = new Contact { FirstName = "New", LastName = "Contact", PhoneNumber = "9998887777" };
//            var response = await _client.PostAsync("Contacts",
//                new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json"));

//            response = await _client.GetAsync("Contacts");

//            var contacts = JsonConvert.DeserializeObject<List<Contact>>(await response.Content.ReadAsStringAsync());

//            contact = contacts.FirstOrDefault(x => x.FirstName == "New");

//            contact.FirstName = "Updated";
//            contact.LastName = "Contact";

//            response = await _client.PutAsync($"Contacts/{contacts[^1].Id}",
//                        new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json"));

//            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
//        }

//        [Fact]
//        public async Task Delete_Should_ResultInOK()
//        {
//            var contact = new Contact { FirstName = "New", LastName = "Contact", PhoneNumber = "9998887777" };
//            var response = await _client.PostAsync("Contacts",
//                new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json"));

//            response = await _client.GetAsync("Contacts");

//            var contacts = JsonConvert.DeserializeObject<List<Contact>>(await response.Content.ReadAsStringAsync());

//            contact = contacts.FirstOrDefault(x => x.FirstName == "New");


//            response = await _client.DeleteAsync($"Contacts/{contacts[^1].Id}");

//            response.StatusCode.Should().Be(HttpStatusCode.OK);
//        }

//        [Fact]
//        public async Task Get_Should_Retrieve_Contacts()
//        {
//            var response = await _client.GetAsync("Contacts");
//            response.StatusCode.Should().Be(HttpStatusCode.OK);

//            var contacts = JsonConvert.DeserializeObject<List<Contact>>(await response.Content.ReadAsStringAsync());
//            contacts.Should().NotBeNull().And.NotBeEmpty();
//        }

//        [Theory]
//        [InlineData("Contacts")]
//        //[InlineData("/Contacts/DACCAA7F-DC20-4344-1DC9-08D88B265920")]
//        public async Task Endpoints_Should_ResultInOK(string endpoint)
//        {

//            var response = await _client.GetAsync(endpoint);
//            response.StatusCode.Should().Be(HttpStatusCode.OK);
//        }


//    }


//}


