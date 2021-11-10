using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="ChannelReader{T}"/>
    /// </summary>
    public static class ChannelExtension
    {
        /// <summary>
        /// Extension method to listen to channel with callback syntax
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channel"></param>
        /// <param name="onMessageRecieved"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task OnMessageRecieved<T>(this ChannelReader<T> channel, Func<T, Task> onMessageRecieved, CancellationToken token)
        {
            while (await channel.WaitToReadAsync(token))
            {
                while (channel.TryRead(out T? item))
                {
                    await onMessageRecieved(item);
                }
            }
        }
    }
}
