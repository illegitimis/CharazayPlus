
namespace CharazayPlus.WebApi.Models
{
  using System;
using AndreiPopescu.CharazayPlus.Model;
using CharazayPlus.WebApi.Infrastructure;
using ProtoBuf;

  [ProtoContract]
  public class ProtoBookmark : ConvertibleTo<BookmarkDTO>
  {
    #region protobuf poco

    [ProtoMember(1, IsRequired = true)]
    public ST_PlayerPositionEnum Position { get; set; }

    [ProtoMember(2, IsRequired = true)]
    public double ValueIndex { get; set; }

    [ProtoMember(3, IsRequired = true)]
    public double TotalScore { get; set; }

    [ProtoMember(4, IsRequired = false)]
    public double DefensiveScore { get; set; }

    [ProtoMember(5, IsRequired = false)]
    public double OffensiveScore { get; set; }

    [ProtoMember(6, IsRequired = false)]
    public double OffensiveAbility { get; set; }

    [ProtoMember(7, IsRequired = false)]
    public double ShootingScore { get; set; }

    [ProtoMember(8, IsRequired = true)]
    public double TransferMarketValue { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [ProtoMember(9, IsRequired = true)]
    public int CharazayId { get; set; }

    [ProtoMember(10, IsRequired = false)]
    public string FullName { get; set; }

    [ProtoMember(11, IsRequired = true)]
    public DateTime When { get; set; }

    [ProtoMember(12, IsRequired = true)]
    public DateTime Deadline { get; set; }

    /// <summary>
    /// price in millions
    /// </summary>
    [ProtoMember(13, IsRequired = true)]
    public double Price { get; set; }

    #endregion


    internal static ProtoBookmark CreateProto(string value)
    {
      throw new NotImplementedException();
    }

    public override BookmarkDTO Convert()
    {
      return new BookmarkDTO()
      {
        CharazayId = this.CharazayId,
        Deadline = this.Deadline.ToString(BookmarkDTO.DATE_FORMAT),
        DefensiveScore = this.DefensiveScore,
        FullName = this.FullName,
        OffensiveAbility = this.OffensiveAbility,
        OffensiveScore = this.OffensiveScore,
        Position = this.Position,
        Price = this.Price,
        ShootingScore = this.ShootingScore,
        TotalScore = this.TotalScore,
        TransferMarketValue = this.TransferMarketValue,
        ValueIndex = this.ValueIndex,
        When = this.When.ToString(BookmarkDTO.DATE_FORMAT)
      };
    }

   
  }
}