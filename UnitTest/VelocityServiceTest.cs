using AzureDevOpsTeamMembersVelocity.Model;
using AzureDevOpsTeamMembersVelocity.Services;
using AzureDevOpsTeamMembersVelocity;
using System.Collections.Generic;
using System.IO;
using Xunit;
using System.Text.Json;

namespace UnitTest
{
    public class VelocityServiceTest
    {
        [Fact]
        public void GroupByPerson()
        {
            var workItem = JsonSerializer.Deserialize<WorkItem>(
                File.ReadAllText(Path.Combine(Constante.ExampleFolder, "workitem.json")), Program.SerializerOptions);
            
            var workItemUpdates = JsonSerializer.Deserialize<ListResponse<WorkItemUpdate>>(
                File.ReadAllText(Path.Combine(Constante.ExampleFolder, "workitemupdates.json")), Program.SerializerOptions);

            var groupBy = new Dictionary<string, MemberVelocity>();

            if (workItem is null || workItemUpdates is null)
            {
                Assert.NotNull(workItem);
                Assert.NotNull(workItemUpdates);
                return;
            }

            VelocityService.GroupByPerson(groupBy, workItem, workItemUpdates.Value);

            Assert.Single(groupBy.Keys);
            Assert.True(groupBy.ContainsKey("John Doe"));

            var velocity = groupBy["John Doe"];

            Assert.Equal("John Doe", velocity.DisplayName);
            Assert.Equal(15, velocity.HoursOfWorkDone);
        }
    }
}
