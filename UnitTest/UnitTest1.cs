using AzureDevOpsTeamMembersVelocity;
using AzureDevOpsTeamMembersVelocity.Model;
using AzureDevOpsTeamMembersVelocity.Services;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void DeserializeWorkItemUpdatesLink()
        {
            var responsesDeserialized = JsonSerializer.Deserialize<WorkItem>(
                File.ReadAllText(Path.Combine("JsonExample", "workitem.json")), Program.SerializerOptions);

            Assert.NotNull(responsesDeserialized.Links);
            Assert.NotNull(responsesDeserialized.Links.WorkItemUpdates);
            Assert.Equal("https://dev.azure.com/johndoe/74320073-199c-4b53-81ff-37671a8d42a9/_apis/wit/workItems/4/updates",
                responsesDeserialized.Links.WorkItemUpdates.Href);
        }

        [Fact]
        public void DeserializeWorkItemUpdatesResponse()
        {
            var responsesDeserialized = JsonSerializer.Deserialize<ListResponse<WorkItemUpdate>>(
                File.ReadAllText(Path.Combine("JsonExample", "workitemupdates.json")), Program.SerializerOptions);

            Assert.NotNull(responsesDeserialized);
        }

        [Fact] 
        public void GroupByPerson()
        {
            var workItem = JsonSerializer.Deserialize<WorkItem>(
                File.ReadAllText(Path.Combine("JsonExample", "workitem.json")), Program.SerializerOptions);

            var workItemUpdates = JsonSerializer.Deserialize<ListResponse<WorkItemUpdate>>(
                File.ReadAllText(Path.Combine("JsonExample", "workitemupdates.json")), Program.SerializerOptions);

            var groupBy = new Dictionary<string, MemberVelocity>();

            VelocityService.GroupByPerson(groupBy, workItem, workItemUpdates.Value);

            Assert.Single(groupBy.Keys);
            Assert.True(groupBy.ContainsKey("John Doe"));

            var velocity = groupBy["John Doe"];

            Assert.Equal("John Doe", velocity.DisplayName);
            Assert.Equal(15, velocity.HoursOfWorkDone);
        }
    }
}
