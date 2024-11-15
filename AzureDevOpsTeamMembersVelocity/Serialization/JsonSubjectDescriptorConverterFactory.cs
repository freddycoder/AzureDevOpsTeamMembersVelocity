using AzureDevOpsTeamMembersVelocity.Model;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Serialization
{
    /// <summary>
    /// SubjectDescriptor struct JsonConverter
    /// </summary>
    public class JsonSubjectDescriptorConverter : JsonConverter<SubjectDescriptor>
    {
        /// <summary>
        /// Read a SubjectDescriptor by spliting the next string with '.'.
        /// If the result of the split is valid, the subject descriptor is return.
        /// Otherwise, it is a new empty subject descriptor that is return.
        /// </summary>
        public override SubjectDescriptor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var sujetString = reader.GetString()?.Split('.');

            if (sujetString != null && sujetString.Length == 2) 
                return new SubjectDescriptor(sujetString[0], sujetString[1]);

            return new SubjectDescriptor();
        }

        /// <summary>
        /// Write a subject descriptor as a string
        /// </summary>
        public override void Write(Utf8JsonWriter writer, SubjectDescriptor value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}