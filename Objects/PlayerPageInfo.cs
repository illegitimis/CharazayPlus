using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndreiPopescu.CharazayPlus.Objects
{
  /// <summary>
  /// This class holds information that is parsed from a Charazay htm player page
  /// </summary>
  internal class PlayerPageInfo
  {
    /// <summary>
    /// Charazay time, reference
    /// </summary>
    public DateTime Servertime { get; set; }

    public DateTime? Deadline { get; set; }

    public DateTime? Now { get; set; }

    public uint? CurrentBid { get; set; }

    public string LastBidByTeamName { get; set; }

    public uint? LastBidByTeamId { get; set; }

    public uint? StartingPrice { get; set; }

    public bool IsTransferListed { get { return Deadline != null; } }

    /// <summary>
    /// Current price bid for the player
    /// do not allow values less than 10K
    /// </summary>
    public uint? Price { get { if (IsTransferListed) return Math.Max (10000u,Math.Max(CurrentBid.Value, StartingPrice.Value)); else return null; } }
  }
}
