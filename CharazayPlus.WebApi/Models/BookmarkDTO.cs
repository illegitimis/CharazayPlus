
namespace CharazayPlus.WebApi.Models
{
  using System;
  using System.Globalization;
  using AndreiPopescu.CharazayPlus.Model;
  using CharazayPlus.WebApi.Infrastructure;
  using Newtonsoft.Json;
  using Newtonsoft.Json.Converters;

  /// <summary>
  /// bookmark json data transfer object
  /// </summary>
  public class BookmarkDTO
  {
    const string DATE_FORMAT = "yyyy-MM-dd HH:mm";  

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

    public int CharazayId { get; set; }

    public string FullName { get; set; }

    //when 2016-07-22 13:19
    public string When { get; set; }

    // deadline 2016-07-23 09:11
    public /*DateTime*/ string Deadline { get; set; }

    [JsonConverter(typeof(DoubleRound2DecimalsJsonConverter))]
    public double Price { get; set; }


    /// <summary>
    /// spaces replaced with + in form data params 
    /// </summary>
    /// <returns></returns>
    internal ProtoBookmark CreateProto()
    {
      return new ProtoBookmark() { 
        CharazayId = this.CharazayId,
        Deadline = DateTime.ParseExact(this.Deadline, DATE_FORMAT, CultureInfo.InvariantCulture),
        DefensiveScore = this.DefensiveScore,
        FullName = this.FullName.Replace('+',' '),
        OffensiveAbility = this.OffensiveAbility,
        OffensiveScore = this.OffensiveScore,
        Position = this.Position,
        Price = this.Price,
        ShootingScore = this.ShootingScore,
        TotalScore = this.TotalScore,
        TransferMarketValue = this.TransferMarketValue,
        ValueIndex = this.ValueIndex,
        When = DateTime.ParseExact(this.When, DATE_FORMAT, CultureInfo.InvariantCulture),
      };
    }
  }
}
