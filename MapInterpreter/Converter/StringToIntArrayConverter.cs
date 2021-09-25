using System;
using System.Linq;
using Newtonsoft.Json;

namespace MapInterpreter.Converter
{
    public class StringToIntArrayConverter : JsonConverter<int[]>
    {
        public override void WriteJson(JsonWriter writer, int[]? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override int[]? ReadJson(JsonReader reader, Type objectType, int[]? existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var s = (string)reader.Value;
            return s?.Split(" ").Select(int.Parse).ToArray();
        }
    }
}