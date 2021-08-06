using ECountry.Domain.Entities;
using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace ECountry.UnitTests.Domain
{
    public class FormTest
    {
        private const string _formName = "form_name";
        private const string _formDescription = "form_description";

        [Fact]
        public void CreateForm_Success()
        {
            // Arrange

            // Act
            var form = new Form(_formName, _formDescription);

            // Assert
            form.Name.ShouldBe(_formName);
            form.Description.ShouldBe(_formDescription);
        }

        [Fact]
        public void CreateForm_WithEmtpyDescription_Success()
        {
            // Arrange

            // Act
            var form = new Form(_formName);

            form.Name.ShouldBe(_formName);
            form.Description.ShouldBeNull();
        }

        [Fact]
        public void CreateForm_WithEmtpyName_Exception()
        {
            // Arrange

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new Form(null, _formDescription));

            // Assert
            exception.ParamName.ShouldBe("name");
            exception.Message.ShouldBe("Value cannot be null. (Parameter 'name')");
        }

        [Fact]
        public void CreateForm_TooLongName_Exception()
        {
            // Arrange
            var rnd = new Random();

            var tooLongFormName = new string(Enumerable.Range(1, 105).Select(x => (char)rnd.Next('a', 'z')).ToArray());

            // Act
            var exception = Assert.Throws<ArgumentException>(() => new Form(tooLongFormName, _formDescription));

            // Assert
            exception.Message.ShouldBe("'Name' is too long");
        }

        [Fact]
        public void CreateForm_TooLongDescription_Exception()
        {
            // Arrange
            var rnd = new Random();

            var tooLongFormDescription = new string(Enumerable.Range(1, 1005).Select(x => (char)rnd.Next('a', 'z')).ToArray());

            // Act
            var exception = Assert.Throws<ArgumentException>(() => new Form(_formName, tooLongFormDescription));

            // Assert
            exception.Message.ShouldBe("'Description' is too long");
        }
    }
}
