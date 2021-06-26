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
            var sujetString = reader.GetString()?.Split('.');

            if (sujetString != null) 
                return new SubjectDescriptor(sujetString[0], sujetString[1]);

            return new SubjectDescriptor();
        }

        public override void Write(Utf8JsonWriter writer, SubjectDescriptor value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.SubjectType + "." + value.Identifier);
        }
    }
}