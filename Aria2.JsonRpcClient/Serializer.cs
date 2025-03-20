using System.Text.Json;
using System.Text.Json.Nodes;

namespace Aria2.JsonRpcClient
{
    internal static class Serializer
    {
        public static T Deserialize<T>(string value)
        {
            T? obj;
#if NET8_0_OR_GREATER
            var typeInfo = Aria2ClientSerializationContext.Default.GetTypeInfo(typeof(T));
            if (typeInfo is null)
            {
#if UNITTEST
                throw new Exception($"TypeInfo is null for {typeof(T)}. Possible missing [JsonSerializable] on Aria2ClientSerializationContext.");
#endif
                obj = JsonSerializer.Deserialize<T>(value, Aria2ClientSerialization.Options);
            }
            else
            {
                obj = (T?)JsonSerializer.Deserialize(value, typeInfo);
            }
#else
            obj = JsonSerializer.Deserialize<T>(value, Aria2ClientSerialization.Options);
#endif
            if (obj is null)
            {
                throw new Exception("Invalid JSON-RPC response.");
            }

            return obj;
        }

        public static T Deserialize<T>(JsonNode value)
        {
            T? obj;
#if NET8_0_OR_GREATER
            var typeInfo = Aria2ClientSerializationContext.Default.GetTypeInfo(typeof(T));
            if (typeInfo is null)
            {
#if UNITTEST
                throw new Exception($"TypeInfo is null for {typeof(T)}. Possible missing [JsonSerializable] on Aria2ClientSerializationContext.");
#endif
                obj = JsonSerializer.Deserialize<T>(value, Aria2ClientSerialization.Options);
            }
            else
            {
                obj = (T?)JsonSerializer.Deserialize(value, typeInfo);
            }
#else
            obj = JsonSerializer.Deserialize<T>(value, Aria2ClientSerialization.Options);
#endif
            if (obj is null)
            {
                throw new Exception("Invalid JSON-RPC response.");
            }

            return obj;
        }

        public static T Deserialize<T>(JsonElement value)
        {
            T? obj;
#if NET8_0_OR_GREATER
            var typeInfo = Aria2ClientSerializationContext.Default.GetTypeInfo(typeof(T));
            if (typeInfo is null)
            {
#if UNITTEST
                throw new Exception($"TypeInfo is null for {typeof(T)}. Possible missing [JsonSerializable] on Aria2ClientSerializationContext.");
#endif
                obj = value.Deserialize<T>(Aria2ClientSerialization.Options);
            }
            else
            {
                obj = (T?)value.Deserialize(typeInfo);
            }
#else
            obj = value.Deserialize<T>(Aria2ClientSerialization.Options);
#endif
            if (obj is null)
            {
                throw new Exception("Invalid JSON-RPC response.");
            }

            return obj;
        }

        public static object Deserialize(JsonElement jsonElement, Type returnType)
        {
            object? obj;
#if NET8_0_OR_GREATER
            var typeInfo = Aria2ClientSerializationContext.Default.GetTypeInfo(returnType);
            if (typeInfo is null)
            {
#if UNITTEST
                throw new Exception($"TypeInfo is null for {typeof(T)}. Possible missing [JsonSerializable] on Aria2ClientSerializationContext.");
#endif
                obj = jsonElement.Deserialize(returnType, Aria2ClientSerialization.Options);
            }
            else
            {
                obj = jsonElement.Deserialize(typeInfo);
            }
#else
            obj = jsonElement.Deserialize(returnType, Aria2ClientSerialization.Options);
#endif
            if (obj is null)
            {
                throw new Exception("Invalid JSON-RPC response.");
            }

            return obj;
        }

        public static string Serialize<T>(T value)
        {
#if NET8_0_OR_GREATER
            var typeInfo = Aria2ClientSerializationContext.Default.GetTypeInfo(typeof(T));
            if (typeInfo is null)
            {
#if UNITTEST
                throw new Exception($"TypeInfo is null for {typeof(T)}. Possible missing [JsonSerializable] on Aria2ClientSerializationContext.");
#endif
                return JsonSerializer.Serialize(value, Aria2ClientSerialization.Options);
            }
            else
            {
                return JsonSerializer.Serialize(value, typeInfo);
            }
#else
            return JsonSerializer.Serialize(value, Aria2ClientSerialization.Options);
#endif
        }
    }
}
