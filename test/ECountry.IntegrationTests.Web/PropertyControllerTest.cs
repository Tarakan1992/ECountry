using ECountry.Application.Features.Fields.Commands;
using ECountry.Application.Features.Fields.Models;
using ECountry.Domain;
using ECountry.Web;
using Hommy.ResultModel;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace ECountry.IntegrationTests.Web
{
    public class PropertyControllerTest : IntegrationTest
    {
        public PropertyControllerTest(WebApplicationFactory<Startup> fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task GetProperties_Success()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync("api/property");

            // Assert
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);

            var result = await response.Content.ReadAsAsync<Result<PropertyModel[]>>();

            result.Data.ShouldNotBeEmpty();
            result.Data.ShouldAllBe(x => x.Name != null);
            result.Data.ShouldAllBe(x => x.Type != 0);
        }

        [Theory]
        [InlineData(PropertyType.Number)]
        [InlineData(PropertyType.String)]
        [InlineData(PropertyType.DateTime)]
        public async Task CreateProperty_Success(PropertyType propertyType)
        {
            // Arrange
            var propertyName = $"Property_{DateTime.UtcNow.Ticks}";

            // Act
            var response = await _client.PostJsonAsync("api/property", new CreatePropertyCommand(propertyName, propertyType));

            // Assert
            response.IsSuccessStatusCode.ShouldBeTrue();

            response = await _client.GetAsync("api/property");

            response.IsSuccessStatusCode.ShouldBeTrue();

            var result = await response.Content.ReadAsAsync<Result<PropertyModel[]>>();

            result.Data.ShouldNotBeEmpty();
            result.Data.FirstOrDefault(x => x.Name == propertyName).ShouldNotBeNull();
        }

        [Fact]
        public async Task CreateProperty_WithoutName_BadRequest()
        {
            // Arrange

            // Act
            var response = await _client.PostJsonAsync("api/property", new CreatePropertyCommand(null, PropertyType.Number));

            // Assert
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.BadRequest);

            var result = await response.Content.ReadAsAsync<Result<PropertyModel[]>>();

            result.Failure.Message.ShouldBe("Validation Error");

            var validationFailure = result.Failure as ValidationFailure;

            validationFailure.ShouldNotBeNull();
            validationFailure.ValidationErrors.First().Message.ShouldBe("'Name' must not be empty.");
        }

        [Fact]
        public async Task CreateProperty_WithoutType_BadRequest()
        {
            // Arrange

            // Act
            var response = await _client.PostJsonAsync("api/property", new CreatePropertyCommand("Property", 0));

            // Assert
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.BadRequest);

            var result = await response.Content.ReadAsAsync<Result<PropertyModel[]>>();

            result.Failure.Message.ShouldBe("Validation Error");

            var validationFailure = result.Failure as ValidationFailure;

            validationFailure.ShouldNotBeNull();
            validationFailure.ValidationErrors.First().Message.ShouldBe("'Type' must not be empty.");
        }

        [Fact]
        public async Task CreateProperty_AlreadyExist_BadRequest()
        {
            // Arrange

            // Act
            var response = await _client.PostJsonAsync("api/property", new CreatePropertyCommand("FirstName", PropertyType.String));

            // Assert
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.BadRequest);

            var result = await response.Content.ReadAsAsync<Result<PropertyModel[]>>();

            result.Failure.Message.ShouldBe("'Property' with name: 'FirstName' already exists");
        }
    }
}
