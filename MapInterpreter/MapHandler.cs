using System.Collections.Generic;
using System.Net.Http.Json;
using MapInterpreter.Converter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MapInterpreter
{
    public static class MapHandler
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public static Map CreateFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Map>(json);
        }

        public class Size
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public class MapSize
        {
            public Size Size { get; set; }
        }

        public class Heights
        {
            [JsonConverter(typeof(StringToIntArrayConverter))]
            public int[] Array { get; set; }
        }

        public class TerrainMap
        {
            public Heights Heights { get; set; }
        }

        public class Target
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
        }

        public class SavedCameraState
        {
            public Target Target { get; set; }
            public double ZoomLevel { get; set; }
            public double HorizontalAngle { get; set; }
            public double VerticalAngle { get; set; }
        }

        public class CameraStateRestorer
        {
            public SavedCameraState SavedCameraState { get; set; }
        }

        public class WaterDepths
        {
            [JsonConverter(typeof(StringToFloatArrayConverter))]
            public float[] Array { get; set; }
        }

        public class Outflows
        {
            public string Array { get; set; }
        }

        public class WaterMap
        {
            public WaterDepths WaterDepths { get; set; }
            public Outflows Outflows { get; set; }
        }

        public class MoistureLevels
        {
            [JsonConverter(typeof(StringToFloatArrayConverter))]
            public float[] Array { get; set; }
        }

        public class SoilMoistureSimulator
        {
            public MoistureLevels MoistureLevels { get; set; }
        }

        public class Singletons
        {
            public MapSize MapSize { get; set; }
            public TerrainMap TerrainMap { get; set; }
            public CameraStateRestorer CameraStateRestorer { get; set; }
            public WaterMap WaterMap { get; set; }
            public SoilMoistureSimulator SoilMoistureSimulator { get; set; }
        }

        public class WaterSource
        {
            public double SpecifiedStrength { get; set; }
            public double CurrentStrength { get; set; }
        }

        public class Coordinates
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
        }

        public class BlockObject
        {
            public Coordinates Coordinates { get; set; }
        }

        public class Components
        {
            public WaterSource WaterSource { get; set; }
            public BlockObject BlockObject { get; set; }
        }

        public class Entity
        {
            public string Id { get; set; }
            public string Template { get; set; }
            public Components Components { get; set; }
        }

        public class Map
        {
            public string GameVersion { get; set; }
            public string Timestamp { get; set; }
            public Singletons Singletons { get; set; }
            public List<Entity> Entities { get; set; }
        }
    }
}