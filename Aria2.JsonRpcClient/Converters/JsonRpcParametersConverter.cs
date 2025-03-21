using System.Text.Json;
using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient.Converters
{
    internal class JsonRpcParametersConverter : JsonConverter<JsonRpcParameters>
    {
        public override JsonRpcParameters Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, JsonRpcParameters value, JsonSerializerOptions options)
        {
            var lastIndex = value.Count - 1;
            while (lastIndex >= 0 && value[lastIndex] is null)
            {
                lastIndex--;
            }

            writer.WriteStartArray();
            for (var i = 0; i <= lastIndex; i++)
            {
                var item = value[i];
                if (item is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    // this ensures that positional parameters can be written as the correct type without affecting objects
                    switch (item)
                    {
                        case int intValue:
                            writer.WriteNumberValue(intValue);
                            continue;
                        case long longValue:
                            writer.WriteNumberValue(longValue);
                            continue;
                        case bool boolValue:
                            writer.WriteBooleanValue(boolValue);
                            continue;
                    }

                    var itemType = item.GetType();
#if NET8_0_OR_GREATER
                    var typeInfo = Aria2ClientSerializationContext.Default.GetTypeInfo(itemType);
                    if (typeInfo is null)
                    {
                        JsonSerializer.Serialize(writer, item, itemType, options);
                    }
                    else
                    {
                        JsonSerializer.Serialize(writer, value[i], typeInfo);
                    }
#else
                    JsonSerializer.Serialize(writer, item, itemType, options);
#endif
                }
            }
            writer.WriteEndArray();
        }
    }
}
