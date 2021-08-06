using ECountry.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Xunit;

namespace ECountry.IntegrationTests.Web
{
    public abstract class IntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly HttpClient _client;

        protected IntegrationTest(WebApplicationFactory<Startup> fixture)
        {
            _client = fixture.CreateClient();
        }
    }
}
