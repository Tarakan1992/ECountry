using System.Collections.Generic;

namespace Hommy.Form
{
    public enum ElementType : byte
    {
        Root = 1,
        Input = 2,
        Select = 3
    }

    public abstract class Element
    {
        public ElementType Type { get; }
        public string Name { get; init; }
        public IReadOnlyDictionary<string, object> Options { get; init; }
        public IReadOnlyCollection<Element> Elements { get; init; }

        protected Element(ElementType type)
        {
            Type = type;
        }
    }


    public class DataElement : Element
    {
        public string Property { get; }

        public DataElement(ElementType type, string property) : base(type)
        {
            Property = property;
        }
    }

    public class RootElement : Element
    {
        public RootElement() : base(ElementType.Root)
        {
        }
    }

    public class InputElement : DataElement
    {
        public InputElement(string property) : base(ElementType.Input, property)
        {
        }
    }

    public class SelectElement : DataElement
    {
        public SelectElement(string property) : base(ElementType.Select, property)
        {
        }
    }

    public class FormDefinition
    {
        public RootElement Root { get; init; }

        public FormDefinition(RootElement root)
        {
            Root = root;
        }
    }
}
