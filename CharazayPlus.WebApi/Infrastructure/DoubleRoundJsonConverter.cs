
namespace CharazayPlus.WebApi.Infrastructure
{
    using System;
    using Newtonsoft.Json;



    /// <summary>
    /// http://stackoverflow.com/a/24180139/2239678
    /// </summary>
    public class DoubleRoundJsonConverter : JsonConverter
    {
        private readonly int _numberOfDecimals;

        public DoubleRoundJsonConverter(int numberOfDecimals)
        {
            _numberOfDecimals = numberOfDecimals;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var d = (double)value;
            var rounded = Math.Round(d, _numberOfDecimals);
            writer.WriteValue((double)rounded);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(double);
        }
    }

    public class DoubleRound2DecimalsJsonConverter : DoubleRoundJsonConverter
    {
        public DoubleRound2DecimalsJsonConverter() : base(2) { }
    }

}