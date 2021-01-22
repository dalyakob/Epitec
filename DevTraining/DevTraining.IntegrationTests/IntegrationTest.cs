using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text.Json;
using Xunit;

namespace DevTraining.IntegrationTests
{
    public abstract class IntegrationTest : IClassFixture<ApiWebApplicationFactory>
    {
        //private readonly Checkpoint _checkpoint = new Checkpoint
        //{
        //    SchemasToInclude = new[] {
        //    "Playground"
        //},
        //    WithReseed = true
        //};

        protected readonly ApiWebApplicationFactory _factory;
        protected readonly HttpClient _client;
        protected readonly IConfiguration _configuration;


        public IntegrationTest(ApiWebApplicationFactory fixture)
        {
            _factory = fixture;
            _client = _factory.CreateClient();

            _configuration = new ConfigurationBuilder()
                  .AddJsonFile("integrationsettings.json")
                  .Build();

            _client.BaseAddress = new Uri(_configuration.GetConnectionString("BaseAddress"));

            //_checkpoint.Reset(_configuration.GetConnectionString("DefaultConnection")).Wait();
        }
    }
}
