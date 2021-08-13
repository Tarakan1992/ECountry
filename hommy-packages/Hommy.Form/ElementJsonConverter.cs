using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Hommy.Form
{
    public class ElementJsonConverter : JsonConverter<Element>
    {
        public override Element Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Element value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
