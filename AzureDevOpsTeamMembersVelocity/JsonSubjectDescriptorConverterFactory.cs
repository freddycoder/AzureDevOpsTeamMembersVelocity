using Microsoft.VisualStudio.Services.Common;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity
{
    public class JsonSubjectDescriptorConverter : JsonConverter<SubjectDescriptor>
    {
        public override SubjectDescriptor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var sujetString = reader.GetString();

            return new SubjectDescriptor("", sujetString);
        }

        public override void Write(Utf8JsonWriter writer, SubjectDescriptor value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Identifier + value.SubjectType);
        }
    }
}