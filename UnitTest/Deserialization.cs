using AzureDevOpsTeamMembersVelocity;
using AzureDevOpsTeamMembersVelocity.Model;
using System.IO;
using System.Text.Json;
using Xunit;

namespace UnitTest
{
    public class Deserialization
    {
        [Fact]
        public void DeserializeWorkItemUpdatesLink()
        {
            var responsesDeserialized = JsonSerializer.Deserialize<WorkItem>(
                File.ReadAllText(Path.Combine(Constante.ExampleFolder, "workitem.json")), Program.SerializerOptions);

            Assert.NotNull(responsesDeserialized.Links);
            Assert.NotNull(responsesDeserialized.Links.WorkItemUpdates);
            Assert.Equal("https://dev.azure.com/johndoe/74320073-199c-4b53-81ff-37671a8d42a9/_apis/wit/workItems/4/updates",
                responsesDeserialized.Links.WorkItemUpdates.Href);
        }

        [Fact]
        public void DeserializeWorkItemUpdatesResponse()
        {
            var responsesDeserialized = JsonSerializer.Deserialize<ListResponse<WorkItemUpdate>>(
                File.ReadAllText(Path.Combine(Constante.ExampleFolder, "workitemupdates.json")), Program.SerializerOptions);

            Assert.NotNull(responsesDeserialized);
        }
    }
}
