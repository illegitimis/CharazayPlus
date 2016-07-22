namespace CharazayPlus.WebApi.Models
{
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
    public double DefensiveScore { get; set; }

    [JsonConverter(typeof(DoubleRound2DecimalsJsonConverter))]
    public double OffensiveScore { get; set; }

    [JsonConverter(typeof(DoubleRound2DecimalsJsonConverter))]
    public double OffensiveAbility { get; set; }

    [JsonConverter(typeof(DoubleRound2DecimalsJsonConverter))]
    public double ShootingScore { get; set; }

    [JsonConverter(typeof(DoubleRound2DecimalsJsonConverter))]
    public double TransferMarketValue { get; set; }
  }
}