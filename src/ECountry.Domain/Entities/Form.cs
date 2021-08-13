using ECountry.Domain.Entities;
using Hommy.Form;
using System;

namespace ECountry.Domain.Entities
{
    public class Form : PublicEntity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public FormDefinition Definition { get; private set; }

        public Form(string name, string description, FormDefinition definition)
        {
            if(name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if(description == null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            if (name.Length > 100)
            {
                throw new ArgumentException("'Name' is too long");
            }

            if(description?.Length > 1000)
            {
                throw new ArgumentException("'Description' is too long");
            }

            Name = name;
            Definition = definition ?? throw new ArgumentNullException(nameof(definition));
            Description = description;
        }
    }
}
