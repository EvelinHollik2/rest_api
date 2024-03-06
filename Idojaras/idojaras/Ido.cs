﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Idojaras;
//
//    var ido = Ido.FromJson(jsonString);

using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Idojaras
{
    
    public partial class Ido
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("current_weather")]
        public string CurrentWeather { get; set; }

        [JsonProperty("temp")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Temp { get; set; }

        [JsonProperty("expected_temp")]
        public string ExpectedTemp { get; set; }

        [JsonProperty("insight_heading")]
        public string InsightHeading { get; set; }

        [JsonProperty("insight_description")]
        public string InsightDescription { get; set; }

        [JsonProperty("wind")]
        public string Wind { get; set; }

        [JsonProperty("humidity")]
        public string Humidity { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("uv_index")]
        public string UvIndex { get; set; }

        [JsonProperty("aqi")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Aqi { get; set; }

        [JsonProperty("aqi_remark")]
        public string AqiRemark { get; set; }

        [JsonProperty("aqi_description")]
        public string AqiDescription { get; set; }

        [JsonProperty("last_update")]
        public string LastUpdate { get; set; }

        [JsonProperty("bg_image")]
        public Uri BgImage { get; set; }
    }

    public partial class Ido
    {
        public static Ido FromJson(string json) => JsonConvert.DeserializeObject<Ido>(json, Idojaras.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Ido self) => JsonConvert.SerializeObject(self, Idojaras.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}