using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using BrightIdeasSoftware;

namespace AndreiPopescu.CharazayPlus.Objects
{
  /// <summary>
  /// object bound to search tm user control
  /// </summary>
  class TransferListedPlayer
  {
    //Deadline when bidding is over	
    
    [OLVColumn(DisplayIndex = 0, IsEditable = false, Width = 100, MinimumWidth = 75, MaximumWidth = 150, Title = "Deadline", AspectToStringFormat = "{0:yyyy.MM.dd HH:mm}")]
    public DateTime Deadline {get; private set;}
    
    //Player Name 	
    [OLVColumn(DisplayIndex = 1, IsEditable = false, Width = 130, MinimumWidth = 40, MaximumWidth = 200, Title = "Player", Hyperlink=true)]
    public string PlayerName {get; private set;}
    public uint PlayerId {get; private set;}

    //Team Name 	
    [OLVColumn(DisplayIndex = 2, IsEditable = false, Width = 130, MinimumWidth = 40, MaximumWidth = 200, Title = "Owner", Hyperlink = true)]
    public string OwnerTeamName {get; private set;}
    public uint OwnerTeamId {get; private set;}

    //Skills Index 	
    [OLVColumn(DisplayIndex = 3, IsEditable = false, Width = 75, MinimumWidth = 40, MaximumWidth = 100, AspectToStringFormat = "{0:N0}", Title = "Skills Index")]
    public uint SkillsIndex {get; private set;}

    //StartingPrice 
    [OLVColumn(DisplayIndex = 4, IsEditable = false, Width = 95, MinimumWidth = 50, MaximumWidth = 120, Title = "Starting Price", AspectToStringFormat = "{0:N0}")]
    public uint StartingPrice {get; private set;}
    
    //Current Bid 	
    [OLVColumn(DisplayIndex = 5, IsEditable = false, Width = 95, MinimumWidth = 50, MaximumWidth = 120, Title = "Current Bid", AspectToStringFormat = "{0:N0}")]
    public uint Bid {get; private set;}

    //Current Bid 	
    [OLVColumn(DisplayIndex = 6, IsEditable = false, Width = 95, MinimumWidth = 50, MaximumWidth = 120, Title = "Current Price", AspectToStringFormat = "{0:N0}")]
    public uint CurrentPrice { get { return Math.Max(StartingPrice, Bid) ;} }

    //Current Bid holder
    [OLVColumn(DisplayIndex = 7, IsEditable = false, Width = 130, MinimumWidth = 40, MaximumWidth = 200, Title = "Bid holder", Hyperlink = true)]
    public string BidHolderTeamName {get; private set;}
    public uint BidHolderTeamId {get; private set;}

        

    //"2014-08-23 01:45, ?act=player&code=1&id=3436214, Juan Jaspe, ?act=team&id=42132,  Aruba Aloe Warriors , 846,083, 0, 140,001, ?act=team&id=52829, Chasseur de tête"
    //"2014-08-21 20:58, ?act=player&code=1&id=19903991, Adolfo Javelosa, ?act=team&id=12998,  Jeepney , 803,880, 0, 2,660,000, ?act=team&id=26241, Bulacan Basketball Club"
    public TransferListedPlayer (IList<string> strings)
    {

      Deadline = DateTime.ParseExact(strings[0], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
      PlayerId = uint.Parse(strings[1].Replace("?act=player&code=1&id=", string.Empty));
      PlayerName = strings[2].Trim();
      OwnerTeamId = TeamId(strings[3]);
      OwnerTeamName = strings[4].Trim();
      SkillsIndex = uint.Parse(strings[5], NumberStyles.AllowThousands | NumberStyles.Integer, CultureInfo.InvariantCulture);
      StartingPrice = uint.Parse(strings[6], NumberStyles.AllowThousands | NumberStyles.Integer, CultureInfo.InvariantCulture);
      Bid = uint.Parse(strings[7], NumberStyles.AllowThousands | NumberStyles.Integer, CultureInfo.InvariantCulture);
      BidHolderTeamId = TeamId(strings[8]);
      BidHolderTeamName = strings[9] ?? strings[9].Trim();
    }

    public TransferListedPlayer (string date, string pn, string pid, string teamown, string teamownid, string si, string prc, string bid, string teambid, string teambidid)
    {
      Deadline = DateTime.ParseExact(date, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
      PlayerId = uint.Parse(pid.Replace("?act=player&code=1&id=", string.Empty));
      PlayerName = pn.Trim();
      OwnerTeamId = TeamId(teamownid);
      OwnerTeamName = TeamName (teamown);
      SkillsIndex = uint.Parse(si, NumberStyles.AllowThousands | NumberStyles.Integer, CultureInfo.InvariantCulture);
      StartingPrice = uint.Parse(prc, NumberStyles.AllowThousands | NumberStyles.Integer, CultureInfo.InvariantCulture);
      Bid = uint.Parse(bid, NumberStyles.AllowThousands | NumberStyles.Integer, CultureInfo.InvariantCulture);
      BidHolderTeamId = TeamId(teambidid);
      BidHolderTeamName = TeamName(teambid);
    }

   

    internal static uint TeamId (string input) 
    { 
      return string.IsNullOrWhiteSpace(input) 
        ? 0u
        : uint.Parse(input.Replace("index.php",string.Empty).Replace("?act=team&id=", string.Empty)); 
    }

    internal static string TeamName (string input)
    {
      return string.IsNullOrWhiteSpace(input)
        ? string.Empty
        : input.Trim();
    }

    internal static uint GetUint (string input)
    {
      return uint.Parse(input.Replace("&euro;",string.Empty).Trim(), NumberStyles.AllowThousands | NumberStyles.Integer, CultureInfo.InvariantCulture);
    }

  }
}
