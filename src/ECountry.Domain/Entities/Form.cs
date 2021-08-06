using ECountry.Domain.Entities.Base;
using System;

namespace ECountry.Domain.Entities
{
    public class Form : PublicEntity
    {
        public string Name { get; private set; }

        public string? Description { get; private set; }

        public Form(string name, string? description = null)
        {
            if(name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if(name.Length > 100)
            {
                throw new ArgumentException("'Name' is too long");
            }

            if(description?.Length > 1000)
            {
                throw new ArgumentException("'Description' is too long");
            }

            Name = name;
            Description = description;
        }
    }
}
