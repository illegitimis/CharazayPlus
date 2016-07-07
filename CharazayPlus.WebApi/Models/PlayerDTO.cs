namespace CharazayPlus.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AndreiPopescu.CharazayPlus.Model;
    using CharazayPlus.WebApi.Infrastructure;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    class PlayerDTO
    {
        //http://stackoverflow.com/questions/2441290/json-serialization-of-enum-as-string#2441379
        [JsonConverter(typeof(StringEnumConverter))]
        public ST_PlayerPositionEnum Position { get; set; }

        [JsonConverter(typeof(DoubleRound2DecimalsJsonConverter))]
        public double ValueIndex { get; set; }

        [JsonConverter(typeof(DoubleRound2DecimalsJsonConverter))]
        public double TotalScore { get; set; }

        [JsonConverter(typeof(DoubleRound2DecimalsJsonConverter))]
        public double DefScore { get; set; }

        [JsonConverter(typeof(DoubleRound2DecimalsJsonConverter))]
        public double OfScore { get; set; }

        [JsonConverter(typeof(DoubleRound2DecimalsJsonConverter))]
        public double OfAbility { get; set; }

        [JsonConverter(typeof(DoubleRound2DecimalsJsonConverter))]
        public double Shoot { get; set; }

        [JsonConverter(typeof(DoubleRound2DecimalsJsonConverter))]
        public double TransferMarketValue { get; set; }
    }
}