using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Globalization;

namespace RestSharpLib.Serializers
{
    public class CustomDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string value = reader.GetString();
                if (DateTime.TryParseExact(value, "yyyy-MM-ddTHH:mm:ss.fffzzz", null, DateTimeStyles.RoundtripKind, out DateTime dateTime))
                {
                    return dateTime;
                }
            }
            return DateTime.MinValue; // 혹은 예외를 throw하여 오류 처리 가능
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz"));
        }
    }
}
