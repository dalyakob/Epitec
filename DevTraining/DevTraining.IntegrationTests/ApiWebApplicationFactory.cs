using AutoMapper;
using DevTraining;
using DevTraining.Api;
using DevTraining.Infrastructure.Data;
using DevTraining.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RepoDb;

namespace DevTraining.IntegrationTests
{
    public class ApiWebApplicationFactory : WebApplicationFactory<Startup>
    {
        //protected override void ConfigureWebHost(IWebHostBuilder builder)
        //{
        //    builder.ConfigureAppConfiguration(config =>
        //    {
        //        var integrationConfig = new ConfigurationBuilder()
        //          .AddJsonFile("integrationsettings.json")
        //          .Build();
        //        config.AddConfiguration(integrationConfig);
        //    });
        //}
        
    }
}