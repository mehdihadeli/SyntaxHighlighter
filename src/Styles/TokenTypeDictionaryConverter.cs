using System.Text.Json;
using System.Text.Json.Serialization;
using Humanizer;

namespace SyntaxHighlighter.Styles;
public class TokenTypeDictionaryConverter : JsonConverter<Dictionary<TokenType, TokenStyle>>
{
    public override Dictionary<TokenType, TokenStyle> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dictionary = new Dictionary<TokenType, TokenStyle>();

        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return dictionary;
            }

            // Read the token type as a string
            string propertyName = reader.GetString() ?? throw new JsonException("Property name expected");
            // Use Humanizer to convert the property name to a TokenType enum
            var tokenType = propertyName.Humanize().Transform(To.TitleCase).DehumanizeTo<TokenType>();
            if (!Enum.IsDefined(typeof(TokenType), tokenType))
            {
                throw new JsonException($"Unknown TokenType: {propertyName}");
            }

            // Read the associated TokenStyle
            reader.Read(); // Move to the value token
            var tokenStyle = JsonSerializer.Deserialize<TokenStyle>(ref reader, options);

            dictionary[tokenType] = tokenStyle ?? throw new JsonException($"Error in deserializing TokenStyle: {tokenStyle}");
        }

        throw new JsonException("Invalid JSON format for dictionary");
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<TokenType, TokenStyle> value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        foreach (var kvp in value)
        {
            // Use Humanizer to convert the enum value to a readable string
            writer.WritePropertyName(kvp.Key.Humanize());
            JsonSerializer.Serialize(writer, kvp.Value, options);
        }
        writer.WriteEndObject();
    }
}