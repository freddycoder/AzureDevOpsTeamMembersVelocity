using System.Collections.Generic;
using System.Text.Json;

namespace AzureDevOpsTeamMembersVelocity.Extensions
{
    /// <summary>
    /// Extension class to help work with the Fields property of Microsoft DevOps models
    /// </summary>
    public static class DictionaireExtension
    {
        /// <summary>
        /// Get the value of a corresponding key or null of the dictionary does not contain the key.
        /// </summary>
        /// <exception cref="System.ArgumentNullException" />
        public static TValue? MaybeGet<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                return value;
            }

            return default;
        }

        /// <summary>
        /// Get the value of a corresponding key. If the value is present, ToString is called on the object 
        /// and System.Json.Text deserialization will be executed on this value.
        /// </summary>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="JsonException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        public static TValue? MaybeGet<TValue>(this IDictionary<string, object> dictionary, string key)
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                return JsonSerializer.Deserialize<TValue>(value?.ToString() ?? "", Program.SerializerOptions);
            }

            return default;
        }

        /// <summary>
        /// TryGet the value of the corresponding key. If the value is 
        /// present, a cast is applied, and the value is returned.
        /// </summary>
        /// <typeparam name="T">Type of the corresponding value</typeparam>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidCastException"></exception>
        public static T? Get<T>(this IReadOnlyDictionary<string, object> dictionary, string key)
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                return (T) value;
            }

            return default;
        }

        /// <summary>
        /// TryGet the value of the corresponding key. If the value is present, a cast 
        /// is applied, and the value is returned.
        /// </summary>
        /// <typeparam name="T">Type of the corresponding value</typeparam>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidCastException"></exception>
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
