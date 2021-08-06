using Hommy.ResultModel;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ECountry.IntegrationTests.Web
{
    public class FailureJsonConverter : JsonConverter<Failure>
    {
        public override Failure Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (JsonDocument.TryParseValue(ref reader, out var doc))
            {
                if(doc.RootElement.TryGetProperty("message", out var messageProperty))
                {
                    if (doc.RootElement.TryGetProperty("validationErrors", out var validationErrorsProperty))
                    {
                        var validationErrors = JsonSerializer.Deserialize<ValidationError[]>(validationErrorsProperty.GetRawText(), options);

                        return new ValidationFailure(validationErrors, messageProperty.ToString());
                    }

                    return new BadRequestFailure(messageProperty.ToString());
                }
            }

            throw new JsonException("Failed to parse");
        }

        public override void Write(Utf8JsonWriter writer, Failure value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
