using System.Collections.Generic;
using System.Text.Json;

namespace AzureDevOpsTeamMembersVelocity.Extensions
{
    public static class DictionaireExtension
    {
        public static TValue? MaybeGet<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                return value;
            }

            return default;
        }

        public static TValue? MaybeGet<TValue>(this IDictionary<string, object> dictionary, string key)
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                return JsonSerializer.Deserialize<TValue>(value?.ToString() ?? "", Program.SerializerOptions);
            }

            return default;
        }

        public static T? Get<T>(this IReadOnlyDictionary<string, object> dictionary, string key)
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                return (T) value;
            }

            return default;
        }

        public static T? Get<T>(this IDictionary<string, object> dictionary, string key)
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                return (T)value;
            }

            return default;
        }
    }
}
