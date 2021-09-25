using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

namespace MapInterpreter.Converter
{
    public class StringToFloatArrayConverter : JsonConverter<float[]>
    {
        public override void WriteJson(JsonWriter writer, float[]? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override float[]? ReadJson(JsonReader reader, Type objectType, float[]? existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var s = (string)reader.Value;
            return s?.Split(" ").Select(s1 => float.Parse(s1, CultureInfo.InvariantCulture)).ToArray();
        }
    }
}