using ECountry.Web;
using Hommy.ResultModel;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace ECountry.IntegrationTests.Web
{
    public class AppControllerTest : IntegrationTest
    {
        private const string _dbVersion = "100";

        public AppControllerTest(WebApplicationFactory<Startup> fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task GetDbVersion_Success()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync("api/ping");

            // Assert
            response.IsSuccessStatusCode.ShouldBeTrue();

            var result = await response.Content.ReadAsAsync<Result<string>>();

            result.Data.ShouldBe(_dbVersion);
        }

    }
}
