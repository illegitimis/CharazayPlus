

namespace AndreiPopescu.CharazayPlus.Objects
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Globalization;
  using AndreiPopescu.CharazayPlus.Utils;
  using AndreiPopescu.CharazayPlus.Extensions;

  /// <summary>
  /// an abstractization for a player transfer as shown by the site, e.g.
  /// S11 W3 D1, 2008-02-08 19:25 	8th Wonder of the World 	Mpempides 	14,487 	8,000,000
  /// S10 W16 D6, 2008-01-16 12:15 	Promoted to the first team 		
  /// </summary>
  internal class SitePlayerTransferHistory
  {
    public SitePlayerTransferHistory (string date, string from, string fromid, string to, string toid, string si, string price)
    {
      //S25 W4 D5, 2012-09-11 19:03
      int i=date.IndexOf(',');
      CharazayTransferDate = CharazayDate.Parse (date.Substring(0, i));
      TransferDate = DateTime.ParseExact(date.Substring(i + 2), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
      //
      FromTeamId = TransferListedPlayer.TeamId(fromid);
      FromTeamName = TransferListedPlayer.TeamName(from);
      //
      SkillsIndex = ParsingExtensions.GetUInt (si);
      Price = ParsingExtensions.GetUInt(price);
      //
      ToTeamId = TransferListedPlayer.TeamId(toid);
      ToTeamName = TransferListedPlayer.TeamName(to);
    }

    public SitePlayerTransferHistory (string date, string from, string si)
    {
      int i=date.IndexOf(',');
      CharazayTransferDate = CharazayDate.Parse(date.Substring(0, i));
      TransferDate = ParsingExtensions.GetDate(date.Substring(i + 2));
      FromTeamName = from;
      SkillsIndex = ParsingExtensions.GetUInt(si);      
    }

 

    public DateTime TransferDate { get; set; }

    public uint FromTeamId { get; set; }

    public string FromTeamName { get; set; }

    public uint SkillsIndex { get; set; }

    public uint Price { get; set; }

    public uint ToTeamId { get; set; }

    public string ToTeamName { get; set; }

    public CharazayDate CharazayTransferDate { get; set; }
  }
}
