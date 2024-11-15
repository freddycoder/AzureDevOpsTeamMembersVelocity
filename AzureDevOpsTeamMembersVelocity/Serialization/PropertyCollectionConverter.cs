using AzureDevOpsTeamMembersVelocity.Model;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Serialization
{
    /// <summary>
    /// Converter for the PropertyCollection object
    /// </summary>
    public class PropertyCollectionConverter : JsonConverter<PropertiesCollection>
    {
        /// <inheritdoc />
        public override PropertiesCollection? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var collection = new PropertiesCollection();

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                reader.Read();

                if (reader.TokenType == JsonTokenType.StartObject)
                {
                    reader.Read();
                }

                var propertyName = reader.GetString();

                reader.Read();

                var values = PropertyValue(ref reader);

                collection.Add(propertyName, values);
            }

            return collection;
        }

        private static object PropertyValue(ref Utf8JsonReader reader)
        {
            var dictionary = new Dictionary<string, object?>();

            reader.Read();

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var propertyName = reader.GetString();

                if (propertyName == null)
                {
                    throw new InvalidOperationException("Cannot deserialize an object with a key null.");
                }

                reader.Read();

                object? value = reader.TokenType switch
                {
                    JsonTokenType.String => reader.GetString(),
                    JsonTokenType.Number => reader.GetInt32(),
                    _ => throw new InvalidOperationException($"Cannot deserialize PropertyCollection with inner property of type : {reader.TokenType}"),
                };

                dictionary.Add(propertyName, value);

                reader.Read();
            }

            reader.Read();

            return dictionary;
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, PropertiesCollection value, JsonSerializerOptions options)
        {
            
        }
    }
}
