

namespace AndreiPopescu.CharazayPlus.Objects
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Globalization;
  using AndreiPopescu.CharazayPlus.Utils;


  internal class SitePlayerTransferHistory
  {
    //[OLVColumn(DisplayIndex = 0, IsEditable = false, Width = 100, MinimumWidth = 75, MaximumWidth = 150, Title = "Deadline", AspectToStringFormat = "{0:yyyy.MM.dd HH:mm}")]
    //public DateTime Deadline { get; private set; }

    ////Player Name 	
    //[OLVColumn(DisplayIndex = 1, IsEditable = false, Width = 130, MinimumWidth = 40, MaximumWidth = 200, Title = "Player", Hyperlink = true)]
    //public string PlayerName { get; private set; }
    //public uint PlayerId { get; private set; }

    ////Team Name 	
    //[OLVColumn(DisplayIndex = 2, IsEditable = false, Width = 130, MinimumWidth = 40, MaximumWidth = 200, Title = "Owner", Hyperlink = true)]
    //public string OwnerTeamName { get; private set; }
    //public uint OwnerTeamId { get; private set; }

    ////Skills Index 	
    //[OLVColumn(DisplayIndex = 3, IsEditable = false, Width = 75, MinimumWidth = 40, MaximumWidth = 100, AspectToStringFormat = "{0:N0}", Title = "Skills Index")]
    //public uint SkillsIndex { get; private set; }

    ////StartingPrice 
    //[OLVColumn(DisplayIndex = 4, IsEditable = false, Width = 95, MinimumWidth = 50, MaximumWidth = 120, Title = "Starting Price", AspectToStringFormat = "{0:N0}")]
    //public uint StartingPrice { get; private set; }

    ////Current Bid 	
    //[OLVColumn(DisplayIndex = 5, IsEditable = false, Width = 95, MinimumWidth = 50, MaximumWidth = 120, Title = "Current Bid", AspectToStringFormat = "{0:N0}")]
    //public uint Bid { get; private set; }

    ////Current Bid 	
    //[OLVColumn(DisplayIndex = 6, IsEditable = false, Width = 95, MinimumWidth = 50, MaximumWidth = 120, Title = "Current Price", AspectToStringFormat = "{0:N0}")]
    //public uint CurrentPrice { get { return Math.Max(StartingPrice, Bid); } }

    ////Current Bid holder
    //[OLVColumn(DisplayIndex = 7, IsEditable = false, Width = 130, MinimumWidth = 40, MaximumWidth = 200, Title = "Bid holder", Hyperlink = true)]
    //public string BidHolderTeamName { get; private set; }
    //public uint BidHolderTeamId { get; private set; }
    
   

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
      SkillsIndex = String.IsNullOrWhiteSpace(si)
        ? 0
        : uint.Parse(si, NumberStyles.AllowThousands | NumberStyles.Integer, CultureInfo.InvariantCulture);      
      Price = uint.Parse(price, NumberStyles.AllowThousands | NumberStyles.Integer, CultureInfo.InvariantCulture);
      //
      ToTeamId = TransferListedPlayer.TeamId(toid);
      ToTeamName = TransferListedPlayer.TeamName(to);
    }

    public SitePlayerTransferHistory (string date, string from, string si)
    {
      int i=date.IndexOf(',');
      CharazayTransferDate = CharazayDate.Parse(date.Substring(0, i));
      TransferDate = DateTime.ParseExact(date.Substring(i + 2), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
      FromTeamName = from;
      SkillsIndex = String.IsNullOrWhiteSpace(si) ? 0 
        : uint.Parse(si, NumberStyles.AllowThousands | NumberStyles.Integer, CultureInfo.InvariantCulture);      
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
