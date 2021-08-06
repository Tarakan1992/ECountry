using ECountry.Domain;
using ECountry.Domain.Entities;
using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace ECountry.UnitTests.Domain
{
    public class PropertyTest
    {
        private const string _propertyName = "property_name";

        [Theory]
        [InlineData(PropertyType.Number)]
        [InlineData(PropertyType.String)]
        [InlineData(PropertyType.DateTime)]
        public void CreateProperty_Success(PropertyType propertyType)
        {
            // Arrange

            // Act
            var property = new Property(_propertyName, propertyType);

            // Assert
            property.Name.ShouldBe(_propertyName);
            property.Type.ShouldBe(propertyType);
        }

        [Fact]
        public void CreateProperty_EmptyName_Exception()
        {
            // Arrange

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new Property(null, PropertyType.String));

            // Assert
            exception.ParamName.ShouldBe("name");
            exception.Message.ShouldBe("Value cannot be null. (Parameter 'name')");
        }

        [Fact]
        public void CreateProperty_InvalidPropertyType_Exception()
        {
            // Arragne

            // Act
            var exception = Assert.Throws<ArgumentException>(() => new Property(_propertyName, 0));

            // Assert
            exception.Message.ShouldBe("'Property Type' is invalid");
        }

        [Fact]
        public void CreateProperty_TooLongName_Exception()
        {
            // Arrange
            Random rnd = new Random();

            var tooLongPropertyName = new string(Enumerable.Range(1, 150).Select(x => (char)rnd.Next('a', 'z')).ToArray());

            // Act
            var exception = Assert.Throws<ArgumentException>(() => new Property(tooLongPropertyName, PropertyType.String));

            // Assert
            exception.Message.ShouldBe("'Name' is too long");
        }
    }
}
