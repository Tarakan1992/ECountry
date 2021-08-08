using System.Collections.Generic;

namespace ECountry.Domain.Entities
{
    public abstract class ElementDefinition
    {
        public string Name { get; }

        public IReadOnlyDictionary<string, object> Options { get; }
        public IReadOnlyCollection<ElementDefinition> Fields { get; }

        protected ElementDefinition(string name, IReadOnlyDictionary<string, object> options, IReadOnlyCollection<ElementDefinition> fields)
        {
            Name = name;
            Options = options;
            Fields = fields;
        }

        public object this[string key]
        {
            get
            {
                return Options[key];
            }
        }
    }

    public class FormDefinition : ElementDefinition
    {
        public ElementDefinition[] Fields { get; }

        public FormDefinition()
        {
            Fields = fields;
        }
    }



    public class FieldDefinition : ElementDefinition
    {

        public FieldDefinition(string name) : base(name)
        {
        }
    }

    public class PageDefinition : ElementDefinition
    {
        public PageDefinition(string name) : base(name)
        {
        }
    }

    public enum FieldType : byte
    {
        Label,
        Input,
    }
}
